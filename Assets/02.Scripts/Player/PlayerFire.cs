using System;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때 마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    public GameObject SubBulletPrefab;

    public Transform FirePoint;

    public float CoolTime = 5f;
    private bool CoolDown = false;
    private float OriginCoolTime;

    private bool AutoMode = false;

    private void Start()
    {
        OriginCoolTime = CoolTime;
    }

    // - 생성 위치(총구)
    private void Update()
    {
        if (CoolDown)
        {
            CheckCoolTime();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AutoMode = !AutoMode;
        }

        if (AutoMode)
        {
            Fire();
        }
        else
        {
            // 1. 스페이스바를 누르면
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        if (!CoolDown)
        {
            // 2. 총알 프리팹을 생성한다.
            // Instantiate 는 프리팹을 복사해서 (Monobehaviour를 상속받는) 게임 오브젝트를 생성하고 씬에 넣어주는 기능
            GameObject bullet = Instantiate(BulletPrefab);
            
            bullet.transform.position = FirePoint.position;
            
            CoolDown = true;
            CoolTime = OriginCoolTime;
        }
    }

    private void CheckCoolTime()
    {
        // 쿨타임 이라면
        if (CoolDown)
        {
            CoolTime = CoolTime - Time.deltaTime;
            
            Debug.Log(CoolTime);
        }

        if (CoolTime <= 0)
        {
            CoolDown = false;
        }
        
    }
}
