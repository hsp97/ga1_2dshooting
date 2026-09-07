using UnityEngine;

[CreateAssetMenu(fileName = "ItemTypeSO", menuName = "Scriptable Objects/ItemTypeSO")]
public class ItemTypeSO : ScriptableObject
{
    public ItemType ItemType;
    [Header("확률")]
    public float chance;
}
