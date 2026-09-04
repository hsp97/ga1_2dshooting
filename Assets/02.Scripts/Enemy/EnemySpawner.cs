using Unity.VisualScripting;
using UnityEngine;

enum EnemyType
{
    aim,
    downward,
    homing,
}
// 역할 : 일정 시간마다 적을 생성해준다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    [Header("스폰 간격")][SerializeField] private float _spawnInteval = 3;
    private float _timer = 0;
    [Header("스폰할 프리팹")]
    [SerializeField] public Enemy _aimEnemyPrefab;
    [SerializeField] public Enemy _downwardEnemyPrefab;
    [SerializeField] public Enemy _homingEnemyPrefab;

    private float _random = 0f;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInteval)
        {
            _timer = 0;
            _spawnInteval = UnityEngine.Random.Range(1f, 3f);   // float 1~3 랜덤
            int randomInt = UnityEngine.Random.Range(1, 2);   // int 1~2 랜덤
            Spawn();
        }
    }
    private void Spawn()
    {
        EnemyType enemyType = CalculateRandom();

        Enemy enemy = null;
        switch (enemyType)
        {
            case EnemyType.homing:
                {
                    enemy = Instantiate(_homingEnemyPrefab);
                    break;
                }
            case EnemyType.aim:
                {
                    enemy = Instantiate(_aimEnemyPrefab);
                    break;
                }
            case EnemyType.downward:
                {
                    enemy = Instantiate(_downwardEnemyPrefab);
                    break;
                }
        }

        if (enemy is not null)
        {
            enemy.transform.position = transform.position;
        }
    }

    private EnemyType CalculateRandom()
    {
        _random = UnityEngine.Random.Range(0f, 100f);

        if (_random is <= 100f and >= 80)
        {
            return EnemyType.homing;
        }
        else if (_random is < 80 and >= 50)
        {
            return EnemyType.aim;
        }
        else
        {
            return EnemyType.downward;
        }
    }
}
