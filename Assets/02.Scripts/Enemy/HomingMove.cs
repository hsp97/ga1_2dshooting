using UnityEngine;

public class HomingMove : Enemy
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _angle = 180f;
    // 캐싱 기법
    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("No player found");
            return;
        }
    }
    protected override void Move()
    {
        if (!_player) return;
        Vector3 direction = _player.transform.position - transform.position;
        Vector3 normalizedSpeed = direction.normalized * _moveSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - _angle);

        transform.position = transform.position + normalizedSpeed * Time.deltaTime;

    }
}
