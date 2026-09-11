using UnityEngine;

public enum ItemType
{
    Heal,
    AttackSpeed,
    MoveSpeed
}

[System.Serializable]
public class ItemTypeData
{
    public ItemType Type;
    public int Weight;
}