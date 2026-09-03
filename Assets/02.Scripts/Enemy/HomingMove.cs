using UnityEngine;

public class HomingMove : Enemy
{
    private Vector2 _direction;
    [SerializeField]
    private float _moveSpeed;
    protected override void Move()
    {
        _direction = Player.transform.position - transform.position;
        Vector2 normalizedSpeed = _direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
