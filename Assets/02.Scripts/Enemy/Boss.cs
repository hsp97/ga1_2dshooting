using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private float _moveSpeed;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("No player found");
            return;
        }
    }

    protected override void Move()
    {
        if (!_player) return;
    }
}