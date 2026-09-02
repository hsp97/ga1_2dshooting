using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private float h, v;
    
    private void Start()
    {
    }

    private void Update()
    {
        h = 0;
        v = 1;

        Vector2 direction = Vector2.up; // = new Vector2(h, v);
        transform.Translate(direction * Speed * Time.deltaTime);   
    }
}
