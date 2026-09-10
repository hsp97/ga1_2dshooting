using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _health;

    [SerializeField]
    private float _damage;

    [SerializeField]
    private GameObject _item;
    private Animator _animator;
    // Todo: 에너미가 공격당할때 재생시켜주는 피격 사운드 
    private AudioSource _enemyDamagedAudioSource;
    // 죽을때 생성할 이펙트 프리팹
    [SerializeField] private GameObject _deathEffectPrefab;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        GameObject PlayerSounds = GameObject.Find("Sounds");
        Sounds sounds = PlayerSounds.GetComponent<Sounds>();
        _enemyDamagedAudioSource = sounds.DamagedEnemyAudioSource;
    }

    private void Update()
    {
        Move();
    }
    protected abstract void Move();

    public void CalculateHealth(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("hit");
        _enemyDamagedAudioSource.Play();
        if (_health <= 0)
        {
            SpawnDeathEffect();
            int value = UnityEngine.Random.Range(1, 101);
            // TODO: SO 를 사용해서 리펙토링
            // 이유1 : 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
            // 이유2 : 각 Enemy 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어렵
            if (value > 50)
            {
                Instantiate(_item, transform.position, Quaternion.identity);
            }
            ScoreManager scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
            scoreManager.AddScore(100);
            Destroy(this.gameObject);
        }
        _animator.SetTrigger("idle");
    }

    private void SpawnDeathEffect()
    {
        // Quaternion.identity => 0,0,0 넣어줌(회전 x)
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamge(_damage);
            }

            Destroy(this.gameObject);
        }
    }
}