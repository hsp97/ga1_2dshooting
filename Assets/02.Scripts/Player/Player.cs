using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float _health;

    public void CalculateHealth(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
