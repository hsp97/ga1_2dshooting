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
    [Header("스폰 간격")]
    [SerializeField] private float _spawnInterval = 3;

    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;
    [SerializeField] private EnemyBalanceDataSO _balanceData;

    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            _spawnInterval = UnityEngine.Random.Range(1f, 3f); // float 1~3 랜덤
            // int randomInt = UnityEngine.Random.Range(1, 2);   // int 1~2 랜덤
            Spawn();
        }
    }

    private void Spawn()
    {
        // 가중치 랜덤 선택 (Weight random select)
        // 각 아이템에 항목에 가중치를 부여하고, 가중치가 클수록 높은 확률로 선택되도록 하는 방식
        // 1. 추첨할 수 있는 모든 가중치를 더한다.
        int totalWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.WeightValue;
        }

        // 2. 전체 가중치 범위에서 랜덤한 정수를 뽑는다.
        int randomWeight = Random.Range(0, totalWeight);
        // 3. 가중치를 누적하면서 선택된 구간을 찾는다.
        int cumulativeWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.WeightValue;

            if (randomWeight < cumulativeWeight)
            {
                GameObject enemy = Instantiate(data.Prefab);
                enemy.transform.position = transform.position;
                enemy.GetComponent<Enemy>().SetHealthBalance(GetHealthMultiplier());
                break;
            }
        }
    }

    private float GetHealthMultiplier()
    {
        // Todo: BestScore에 따라 밸런스 데이터의 mulitplier 반환
        float multiplier = 1f;
        int bestScore = ScoreManager.Instance.BestScore;
        foreach (EnemyBalanceData data in _balanceData.Datas)
        {
            if (bestScore < data.RequiredScroe)
            {
                multiplier = data.HealthMultiplier;
                return multiplier;
            }
        }

        // 없다면 제일 마지막 값 반환
        int lastIndex = _balanceData.Datas.Length - 1;
        return _balanceData.Datas[lastIndex].HealthMultiplier;
    }
}