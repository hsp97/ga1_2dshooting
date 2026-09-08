using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    // - 데이터 은닉
    // - 메서드를 통한 상태 변경
    [SerializeField]
    protected float _health;
    // 프로퍼티
    public float Health
    {
        get { return _health; }
    }
    // 
    // 람다식을 문법을 활용한 읽기 전용 프로퍼티
    // public float Health => _health;
    // 
    // 잘 설계된 클래스는
    // - 필드(인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게막고, 정상적으로 동작하는 메서드
    // 
    // getter / setter : 특정 데이터를 get/set 해주는 메서드
    // public float GetHealth() { return _health; }
    private List<PlayerFire> _playerFires = new List<PlayerFire>();

    public void Start()
    {
        _playerFires.AddRange(GetComponentsInChildren<PlayerFire>());
    }
    public void CalculateHealth(float damage)
    {
        if (damage < 0)
        {
            Debug.Log("대미지는 음수일 수 없다");
            return;
        }
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void AddAttackSpeedBuff(float buff)
    {
        foreach (PlayerFire playerFire in _playerFires)
        {
            playerFire.AddAttackSpeed(buff);
        }
    }
    public void AddMoveSpeedBuff()
    {
        PlayerMove playerMove = GetComponent<PlayerMove>();
        playerMove.SpeedUpBuff(1);
    }
    public void HealHp()
    {
        _health += 50;
    }
}
