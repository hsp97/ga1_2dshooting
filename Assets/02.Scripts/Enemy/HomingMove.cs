using UnityEngine;

public class HomingMove : Enemy
{
    // 캐싱 기법
    private GameObject _player;
    [SerializeField]
    private float _moveSpeed;
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
        Vector2 direction = _player.transform.position - transform.position;
        Vector2 normalizedSpeed = direction.normalized * _moveSpeed;
        transform.Translate(normalizedSpeed * Time.deltaTime);
    }
}
