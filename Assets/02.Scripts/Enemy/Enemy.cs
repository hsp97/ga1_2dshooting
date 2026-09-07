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
    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void CalculateHealth(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(this.gameObject);

            int value = UnityEngine.Random.Range(1, 10);
            if (value > 6)
            {
                Instantiate(_item, transform.position, Quaternion.identity);
            }
        }
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