using UnityEngine;

public record UpgradeDto
{
    private string _name;
    private int _level;
    private float _currentValue;
    private float _nextValue;
    private int _cost;
}