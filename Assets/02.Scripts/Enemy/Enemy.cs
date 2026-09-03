using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed;

    private float _h = 0f;
    private float _v = 0f;

    private void Update()
    {
        //Vector2 direction = new Vector2(transform.position.x, transform.position.y);
        // Vector2 normalizedDirection = direction.normalized;

        transform.position = new Vector3(transform.position.x, transform.position.y - _speed * Time.deltaTime,
            transform.position.z);
    }
}