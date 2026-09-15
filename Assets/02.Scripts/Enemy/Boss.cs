using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private float _moveSpeed;

    private GameObject _player;

    private void Start()
    {
        Destroy(gameObject);
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            return;
        }
    }

    protected override void Move()
    {
        if (!_player) return;
    }
}