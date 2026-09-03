using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MoveSpeed;
    public float Damage;
    private void Update()
    {
        Vector2 direction = Vector2.up; // = new Vector2(h, v);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.CalculateHealth(Damage);
            Destroy(this.gameObject);
        }
    }
}