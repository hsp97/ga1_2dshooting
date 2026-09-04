using UnityEngine;

// 역할 : 일정 시간마다 적을 생성해준다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    [Header("스폰 간격")][SerializeField] private float _spawnInteval = 3;
    private float _timer = 0;
    [Header("스폰할 프리팹")][SerializeField] public Enemy _enemyPrefab;
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
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = transform.position;
    }
}
