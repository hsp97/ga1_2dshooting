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

    public void AddAttackSpeedBuff()
    {
        
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
