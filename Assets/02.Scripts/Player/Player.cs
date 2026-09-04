using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float _health;

    public void CalculateHealth(float damge)
    {
        _health -= damge;
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
