using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _health;
    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void CalculateHealth(float damage)
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _health -= damage;
        }
    }
}