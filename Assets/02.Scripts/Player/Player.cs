using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField]
    protected float _health;

    public void CalculateHealth(float damge)
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _health -= damge;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            CalculateHealth(enemy.GetDamage());
            Destroy(collider.gameObject);
        }
    }
}
