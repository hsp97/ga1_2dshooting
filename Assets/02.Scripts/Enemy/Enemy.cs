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
    [SerializeField]
    protected Animator _animator;
    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void CalculateHealth(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("hit");
        if (_health <= 0)
        {
            int value = UnityEngine.Random.Range(1, 101);
            // TODO: SO 를 사용해서 리펙토링
            // 이유1 : 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
            // 이유2 : 각 Enemy 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어렵
            if (value > 6)
            {
                Instantiate(_item, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
        _animator.SetTrigger("idle");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.CalculateHealth(_damage);
            }
            Destroy(this.gameObject);
        }
    }
}