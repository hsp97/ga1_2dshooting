using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private float _health;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();

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
}