using UnityEngine;

public class EnemyMove : Enemy
{
    private Vector2 _direction;
    public float MoveSpeed;
    public EnemyMove(Vector2 direction, float moveSpeed)
    {
        _direction = direction;
        MoveSpeed = moveSpeed;
    }
    private void Update()
    {
        _direction = Player.transform.position - transform.position;
        Vector2 normalizedDirection = _direction.normalized;

        transform.Translate(normalizedDirection * MoveSpeed * Time.deltaTime);
    }
}
