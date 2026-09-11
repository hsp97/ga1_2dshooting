using System;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            collider.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }
}