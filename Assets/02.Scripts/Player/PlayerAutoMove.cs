using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _position;
    private Vector3 _enemyPosition;
    private float _hypo = 9999;
    private float _distanceX;
    private float _distanceY;

    private void Update()
    {
        _position = transform.position;
        _position.x = transform.position.x;
        _position.y = transform.position.y;
        _enemyPosition.y = _enemyPosition.y - 1f;
        Vector3 direction = _enemyPosition - transform.position;
        Vector3 normalizedSpeed = direction.normalized * _speed;
        transform.position += normalizedSpeed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        TrackEnemy();
    }
    private void TrackEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 enemyPosition;
        float enemyHypo = 0;
        _hypo = 9999;
        foreach (GameObject enemy in enemys)
        {
            enemyPosition = enemy.transform.position;
            //Debug.Log($"적의 좌표({enemyPosition.x},{enemyPosition.y})");
            _distanceX = _position.x - enemyPosition.x;
            _distanceY = _position.y - enemyPosition.y;
            if (_hypo > _distanceX * _distanceX + _distanceY * _distanceY)
            {
                _hypo = _distanceX * _distanceX + _distanceY * _distanceY;
                _enemyPosition = enemyPosition;
            }
        }
    }
}
