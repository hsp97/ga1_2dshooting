using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Item : MonoBehaviour
{
    [SerializeField] private float _waitTime = 3;
    [SerializeField] private float _attackSpeedBuff = 0.1f;
    [SerializeField] private GameObject _getEffectPrefab;

    private GameObject _player;
    private float _timer = 0;
    private float _moveSpeed = 10f;
    private float _random;
    private ItemType _itemType;
    void Start()
    {
        _random = UnityEngine.Random.Range(0, 100);
        _itemType = CalculateRandom();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

        switch (_itemType)
        {
            case ItemType.heal:
            {
                spriteRenderer.color = Color.green;
                break;
            }
            case ItemType.attackSpeed:
            {
                spriteRenderer.color = Color.blue;
                break;
            }
            case ItemType.moveSpeed:
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
            Move();
        }
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
                case ItemType.heal:
                {
                    collision.gameObject.GetComponent<Player>().HealHp();
                    break;
                }
                case ItemType.attackSpeed:
                {
                    collision.gameObject.GetComponent<Player>().AddAttackSpeedBuff(_attackSpeedBuff);
                    break;
                }
                case ItemType.moveSpeed:
                {
                    collision.gameObject.GetComponent<Player>().AddMoveSpeedBuff();
                    break;
                }
            }

            Instantiate(_getEffectPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private ItemType CalculateRandom()
    {
        // TODO: SO 를 사용해서 리펙토링
        // 이유1 : 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
        // 이유2 : 각 Enemy 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어렵
        if (_random >= 66)
        {
            return ItemType.heal;
        }
        else if (_random is < 66 and >= 33)
        {
            return ItemType.attackSpeed;
        }
        else
        {
            return ItemType.moveSpeed;
        }
    }
}