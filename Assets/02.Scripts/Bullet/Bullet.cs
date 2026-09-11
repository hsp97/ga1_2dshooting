using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] BulletType _bulletType;
    public BulletType Type => _bulletType;

    public float MoveSpeed;
    public float Damage;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnSpawn()
    {
        // 프리팹이 풀에 의해서 활성화 될때마다 초기화 하는 코드들이 들어간다.
        PlaySound();
    }

    private void PlaySound()
    {
        _audioSource.pitch = UnityEngine.Random.Range(-1.5f, 1.5f);
        _audioSource.Play();
    }

    private void Update()
    {
        Vector2 direction = Vector2.up; // = new Vector2(h, v);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }

    // 트리거 관련 이벤트
    // Collider 가 넘어옴, Collision 이 아님
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.CalculateHealth(Damage);
            this.gameObject.SetActive(false);
        }
    }

    // 충돌이 시작되면 호출되는 함수
    // Collision 이 넘어옴
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.CalculateHealth(Damage);
            Destroy(this.gameObject);
        }
    }
    */
}