using UnityEngine;

public class DownwardEnemy : Enemy
{
    private Vector2 _direction = Vector2.down;
    [SerializeField]
    private float _moveSpeed;
    protected override void Move()
    {
        Vector2 normalizedSpeed = _direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
