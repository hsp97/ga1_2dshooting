// 데이터 클래스: 순수하게 데이터를 보관하고 전달하는 목적으로 만든 클래스 

using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    // 에디터 Drawer가 nameof로 참조하므로 이름 변경 시 자동 반영됨
    public const string PrefabFieldName = nameof(_enemyPrefab);
    public const string WeightFieldName = nameof(_weight);
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField, Min(0)] private int _weight;
    public GameObject Prefab => _enemyPrefab;
    public int WeightValue => _weight;
}