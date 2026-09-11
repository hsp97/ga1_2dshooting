using UnityEditor;
using UnityEngine;

/// <summary>
/// EnemySpawnData를 한 줄로 그리고, 같은 배열 내 비율(%)을 표시한다.
/// </summary>
[CustomPropertyDrawer(typeof(EnemySpawnData))]
public class EnemySpawnDataDrawer : PropertyDrawer
{
    private const float WeightWidth = 60f;
    private const float PercentWidth = 55f;
    private const float Spacing = 4f;
    private const string ArrayToken = ".Array.data[";

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty prefabProp = property.FindPropertyRelative(EnemySpawnData.PrefabFieldName);
        SerializedProperty weightProp = property.FindPropertyRelative(EnemySpawnData.WeightFieldName);

        float prefabWidth = position.width - WeightWidth - PercentWidth - Spacing * 2;
        var prefabRect = new Rect(position.x, position.y, prefabWidth, position.height);
        var weightRect = new Rect(prefabRect.xMax + Spacing, position.y, WeightWidth, position.height);
        var percentRect = new Rect(weightRect.xMax + Spacing, position.y, PercentWidth, position.height);

        EditorGUI.PropertyField(prefabRect, prefabProp, GUIContent.none);
        EditorGUI.PropertyField(weightRect, weightProp, GUIContent.none);

        float percent = CalculatePercent(property, weightProp.intValue);
        EditorGUI.LabelField(percentRect, $"{percent:0.##}%", EditorStyles.boldLabel);

        EditorGUI.EndProperty();
    }

    /// <summary>
    /// propertyPath("datas.Array.data[2]")에서 부모 배열을 찾아 비율을 계산한다.
    /// </summary>
    private static float CalculatePercent(SerializedProperty property, int weight)
    {
        string path = property.propertyPath;
        int tokenIndex = path.LastIndexOf(ArrayToken, System.StringComparison.Ordinal);
        if (tokenIndex < 0) return 100f;

        SerializedProperty arrayProp = property.serializedObject.FindProperty(path.Substring(0, tokenIndex));
        if (arrayProp == null || !arrayProp.isArray) return 0f;

        int total = 0;
        for (int i = 0; i < arrayProp.arraySize; i++)
        {
            total += arrayProp.GetArrayElementAtIndex(i)
                .FindPropertyRelative(EnemySpawnData.WeightFieldName).intValue;
        }

        return total > 0 ? weight * 100f / total : 0f;
    }
}