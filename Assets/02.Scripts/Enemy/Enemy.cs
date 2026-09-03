using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
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
}