using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public float Health;
    public void CalculateHealth(float damge)
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Health -= damge;
        }
    }
}