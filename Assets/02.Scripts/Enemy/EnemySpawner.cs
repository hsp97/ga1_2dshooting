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
    [Header("스폰 간격")][SerializeField] private float _spawnInterval = 3;
    private float _timer = 0;
    [Header("스폰할 프리팹")]
    [SerializeField]
    private Enemy[] _enemyPrefabs;
    private float _random = 0;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            _spawnInterval = UnityEngine.Random.Range(1f, 3f);   // float 1~3 랜덤
            // int randomInt = UnityEngine.Random.Range(1, 2);   // int 1~2 랜덤
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
                    enemy = Instantiate(_enemyPrefabs[(int)EnemyType.homing]);
                    break;
                }
            case EnemyType.aim:
                {
                    enemy = Instantiate(_enemyPrefabs[(int)EnemyType.aim]);
                    break;
                }
            case EnemyType.downward:
                {
                    enemy = Instantiate(_enemyPrefabs[(int)EnemyType.downward]);
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
        _random = UnityEngine.Random.Range(0, 100);

        // TODO: SO 를 사용해서 리펙토링
        // 이유1 : 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
        // 이유2 : 각 Enemy 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어렵
        if (_random >= 80)
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
