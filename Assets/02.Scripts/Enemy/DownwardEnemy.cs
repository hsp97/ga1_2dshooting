using UnityEngine;

public class DownwardEnemy : Enemy
{
    private Vector2 _direction = Vector2.down;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _angle = 90f;
    protected override void Move()
    {
        Vector3 normalizedSpeed = _direction.normalized * _moveSpeed;

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - _angle);

        transform.position = transform.position + normalizedSpeed * Time.deltaTime;
    }
}
