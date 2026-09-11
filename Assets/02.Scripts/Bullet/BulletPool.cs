using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;

    // 오브젝트 풀링이란: 오브젝트의 Pool(웅덩이: 창고)을 만들어두고,
    // 그 창고안에 게임 오브젝트를 미리 필요한 만큼 만들어두고,
    // 필요할 때마다 꺼내서 사용하고 필요가 없으면 반환하는 식으로    (활성화/비활성화)
    // 메모리 할당(객체의 생성)과 해제(파괴)를 최소화해서 성능 향상

    // 필요 속성
    [Header("총알 프리팹들")]
    [SerializeField] private Bullet[] _bulletPrefabs;
    // [SerializeField] private Bullet _bulletPrefab;
    // [SerializeField] private Bullet _subBulletPrefab;

    [Header("풀 사이즈")]
    [SerializeField] private int _poolSize = 50;
    [SerializeField] private int _subPoolSize = 50;

    private Bullet[] _pool;
    private Bullet[] _subPool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        // 풀 크기만큼 총알을 미리 만든다.
        _pool = new Bullet[_poolSize];
        _subPool = new Bullet[_poolSize];
        foreach (Bullet _bulletPrefab in _bulletPrefabs)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
                bullet.gameObject.SetActive(false); // 당장 사용하지 않기에 비활성화

                switch (bullet.Type)
                {
                    case BulletType.Sub:
                    {
                        _subPool[i] = bullet;
                        break;
                    }
                    case BulletType.Main:
                    {
                        _pool[i] = bullet;
                        break;
                    }
                }
            }
        }
    }

    public Bullet GetBullet()
    {
        return BulletSetting(_pool);
    }

    public Bullet GetSubBullet()
    {
        return BulletSetting(_subPool);
    }

    private Bullet BulletSetting(Bullet[] pool)
    {
        foreach (Bullet bullet in pool)
        {
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                bullet.OnSpawn();
                return bullet;
            }
        }

        return null;
    }
}