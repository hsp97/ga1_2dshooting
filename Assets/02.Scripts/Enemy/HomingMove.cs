using UnityEngine;

public class HomingMove : Enemy
{
    private GameObject _player;
    private Vector2 _direction;
    [SerializeField]
    private float _moveSpeed;
    private void Start()
    {
    }
    protected override void Move()
    {
        _player = GameObject.FindWithTag("Player");
        _direction = _player.transform.position - transform.position;
        Vector2 normalizedSpeed = _direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
