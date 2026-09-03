using UnityEngine;

public class EnemyMove : Enemy
{
    private Vector2 _direction;
    public float MoveSpeed;
    public float Health;
    public EnemyMove(Vector2 direction, float moveSpeed, float health)
    {
        _direction = direction;
        MoveSpeed = moveSpeed;
        _health = health;
    }
    private void Start()
    {
        _health = Health;
    }
    private void Update()
    {
        _direction = Player.transform.position - transform.position;
        Vector2 normalizedDirection = _direction.normalized;

        transform.Translate(normalizedDirection * MoveSpeed * Time.deltaTime);
    }
}
