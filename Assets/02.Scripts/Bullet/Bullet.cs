using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    private float _h, _v;

    private void Start()
    {
    }

    private void Update()
    {
        _h = 0;
        _v = 1;

        Vector2 direction = Vector2.up; // = new Vector2(h, v);
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}