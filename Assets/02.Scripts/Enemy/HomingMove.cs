using UnityEngine;

public class HomingMove : Enemy
{
    // 캐싱 기법
    private GameObject _player;
    private Vector2 _direction;
    [SerializeField]
    private float _moveSpeed;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    protected override void Move()
    {
        _direction = _player.transform.position - transform.position;
        Vector2 normalizedSpeed = _direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
