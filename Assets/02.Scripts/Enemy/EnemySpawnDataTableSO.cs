using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataTable", menuName = "Scriptable Objects/EnemySpawnDataTable")]
public class EnemySpawnDataTableSO : ScriptableObject
{
    [SerializeField] private EnemySpawnData[] _datas;
    /// <summary>읽기 전용 스폰 데이터 목록.</summary>
    public IReadOnlyList<EnemySpawnData> Datas => _datas;
    /// <summary>전체 가중치 합.</summary>
    public int TotalWeight
    {
        get
        {
            int total = 0;
            for (int i = 0; i < _datas.Length; i++) total += _datas[i].WeightValue;
            return total;
        }
    }

    /// <summary>가중치에 따라 항목 하나를 뽑는다. 합계가 0이면 null.</summary>
    public EnemySpawnData Pick()
    {
        int total = TotalWeight;
        if (total <= 0) return null;

        int roll = Random.Range(0, total);
        for (int i = 0; i < _datas.Length; i++)
        {
            roll -= _datas[i].WeightValue;
            if (roll < 0) return _datas[i];
        }

        return null;
    }
}