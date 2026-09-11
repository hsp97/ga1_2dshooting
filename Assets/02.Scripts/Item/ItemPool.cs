using UnityEditor.UIElements;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    private static ItemPool _instance = null;
    public static ItemPool Instance => _instance;

    [Header("아이템 프리팹")]
    [SerializeField] private Item _itemPrefabs;

    [Header("아이템 풀 사이즈")]
    [SerializeField] private int _poolSize = 20;

    private Item[] _pool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        _pool = new Item[_poolSize];

        for (int i = 0; i < _poolSize; i++)
        {
            Item item = Instantiate(_itemPrefabs, gameObject.transform);
            item.gameObject.SetActive(false); // 당장 사용하지 않기에 비활성화
            _pool[i] = item;
        }
    }

    public Item GetItem()
    {
        foreach (Item item in _pool)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }

        return null;
    }
}