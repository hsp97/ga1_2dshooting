using UnityEngine;

public class AimedEnemy : Enemy
{
    private Vector2 _direction;
    [SerializeField]
    private float _moveSpeed;
    private void Start()
    {
        _direction = Player.transform.position - transform.position;
    }
    protected override void Move()
    {
        Vector2 normalizedSpeed = _direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
