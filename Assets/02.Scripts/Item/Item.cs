using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    [SerializeField] private float _waitTime = 3;
    [SerializeField] private float _attackSpeedBuff = 0.1f;
    [SerializeField] private GameObject _getEffectPrefab;

    [Header("아이템 타입")]
    [SerializeField] private ItemTypeDataTableSO _itemTypeDatas;

    private GameObject _player;
    private float _timer = 0;
    private float _moveSpeed = 10f;
    private ItemType _itemType;

    void OnEnable()
    {
        ResetTimer();
        _itemType = CalculateRandom();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

        switch (_itemType)
        {
            case ItemType.Heal:
            {
                spriteRenderer.color = Color.green;
                break;
            }
            case ItemType.AttackSpeed:
            {
                spriteRenderer.color = Color.blue;
                break;
            }
            case ItemType.MoveSpeed:
            {
                spriteRenderer.color = Color.white;
                break;
            }
        }

        _player = GameObject.FindWithTag("Player");
        if (_player == null) return;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _waitTime)
        {
            if (_player == null) return;

            Move();
        }
    }

    private void ResetTimer()
    {
        _timer = 0;
    }

    private void Move()
    {
        Vector3 direction = _player.transform.position - transform.position;
        Vector3 normalized = direction.normalized;

        transform.position = transform.position + normalized * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (_itemType)
            {
                // 심화과제1: 퍼사드 패턴(패턴: 객체지향에서 자주 일어나는 설계 문제를 잘 풀어내도록 경험에 의해 정리해놓은 공식같은거)
                // 심화과제2: 아이템 졸류가 폭발적으로 증가할 경우에는 -> 조합 패턴을 사용해라
                case ItemType.Heal:
                {
                    collision.gameObject.GetComponent<Player>().HealHp();
                    break;
                }
                case ItemType.AttackSpeed:
                {
                    collision.gameObject.GetComponent<Player>().AddAttackSpeedBuff(_attackSpeedBuff);
                    break;
                }
                case ItemType.MoveSpeed:
                {
                    collision.gameObject.GetComponent<Player>().AddMoveSpeedBuff();
                    break;
                }
            }

            Instantiate(_getEffectPrefab, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }

    private ItemType CalculateRandom()
    {
        int totalWeight = 0;
        foreach (ItemTypeData data in _itemTypeDatas.Datas)
        {
            totalWeight += data.Weight;
        }

        int randomWeight = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;
        foreach (ItemTypeData data in _itemTypeDatas.Datas)
        {
            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                return data.Type;
            }
        }

        return ItemType.Heal;
    }
}