using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float _health;
    
    private List<PlayerFire> _playerFires = new List<PlayerFire>();

    public void Start()
    {
        _playerFires.AddRange(GetComponentsInChildren<PlayerFire>());
    }

    public void CalculateHealth(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void AddAttackSpeedBuff(float buff)
    {
        foreach(PlayerFire playerFire in _playerFires)
        {
            playerFire.AddAttackSpeed(buff);
        }
    }
    public void AddMoveSpeedBuff()
    {
        PlayerMove playerMove = GetComponent<PlayerMove>();
        playerMove.Speed += 5f;
        
    }
    public void HealHp()
    {
        _health += 50;
    }
}
