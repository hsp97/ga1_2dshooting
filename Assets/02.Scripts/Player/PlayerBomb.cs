using System;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private float _coolTime = 10f;
    [SerializeField] private GameObject _player;
    public GameObject BombPrefab;
    private float _coolTimer;
    private void Update()
    {
        _coolTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.B) && _coolTimer <= 0)
        {
            UseBomb(_player.transform);
        }
    }

    private void UseBomb(Transform playerTransform)
    {
        _coolTimer = _coolTime;

        GameObject bombPrefab = Instantiate(BombPrefab);
        bombPrefab.transform.position = playerTransform.position + new Vector3(-1.5f, 3f, 0);
    }

}
