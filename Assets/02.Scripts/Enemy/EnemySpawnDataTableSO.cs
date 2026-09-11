using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataTable", menuName = "Scriptable Objects/EnemySpawnDataTable")]
public class EnemySpawnDataTable : ScriptableObject
{
    public EnemySpawnData[] Datas;
}
