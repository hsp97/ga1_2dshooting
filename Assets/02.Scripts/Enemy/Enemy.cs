using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _health;

    [SerializeField]
    private float _damage;
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
        }
    }
    public float GetDamage()
    {
        return _damage;
    }
}