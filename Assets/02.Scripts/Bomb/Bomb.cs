using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private GameObject _player;
    public float MoveSpeed = 5f;
    private Vector3 _position;
    private float _existTime = 4;
    private float _damage = 99999f;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _position = _player.transform.position;
    }
    private void Update()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * MoveSpeed * Time.deltaTime);

        if (_position.y + 6f <= transform.position.y)
        {
            _animator.SetTrigger("Explode");
            MoveSpeed = 0;
        }
        if (_existTime > 0)
        {
            _existTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.CalculateHealth(_damage);
        }
    }
}
