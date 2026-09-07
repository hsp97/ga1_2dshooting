using Unity.Mathematics;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Transform _target;
    private Vector3 _p1, _p2, _p3;
    private float _time = 0f;
    public GameObject P1, P2, P3;
    private void Start()
    {
        _p1 = P1.transform.position;
        _p2 = P2.transform.position;
        _p3 = P3.transform.position;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        Vector3 p4 = Vector3.Lerp(_p1, _p2, _time / 1000);
        Vector3 p5 = Vector3.Lerp(_p2, _p3, _time / 1000);
        transform.position = Vector3.Lerp(p4, p5, _time / 1000);
    }
}
