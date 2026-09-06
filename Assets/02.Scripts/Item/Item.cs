using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

enum ItemType
{
    heal,
    attackSpeed,
    moveSpeed
}
public class Item : MonoBehaviour
{
    [SerializeField]
    private float _maxTime = 3;
    [SerializeField]
    private float _attackSpeedBuff = 0.1f;

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
        if( _player == null)
        {
            return;
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if( _timer > _maxTime)
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
