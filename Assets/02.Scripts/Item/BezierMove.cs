using Unity.Mathematics;
using UnityEngine;

public class BezierMove
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
        Vector3 p4 = Vector3.Lerp(_p1, _p2, _time / 10);
        Vector3 p5 = Vector3.Lerp(_p2, _p3, _time / 10);
        //transform.position = Vector3.Lerp(p4, p5, _time / 10);
    }
    private void CalculateMove(GameObject g1, GameObject g2)
    {
        Vector3 p1 = g1.transform.position;
        Vector3 p2 = g2.transform.position;
        Vector3 p3 = new Vector3(0, 0, 0);
    }
    public static void OnMoveBezier(GameObject g1, GameObject g2)
    {
        //CalculateMove(g1, g2);
    }
}
