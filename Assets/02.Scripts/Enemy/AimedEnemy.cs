using UnityEngine;

public class AimedEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;
    [SerializeField]
    private float _moveSpeed;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("No player found");
        }
        _direction = _player.transform.position - transform.position;
    }
    protected override void Move()
    {
        Vector2 normalizedSpeed = _direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
