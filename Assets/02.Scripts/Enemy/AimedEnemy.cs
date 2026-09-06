using Unity.VisualScripting;
using UnityEngine;

public class AimedEnemy : Enemy
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _angle = 90f;

    private GameObject _player;
    private Vector3 _direction;
    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("No player found");
            return;
        }
        _direction = _player.transform.position - transform.position;

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, angle - _angle);
    }
    protected override void Move()
    {
        if (!_player) return;
        Vector3 normalizedSpeed = _direction.normalized * _moveSpeed;

        transform.position = transform.position + normalizedSpeed * Time.deltaTime;
    }
}
