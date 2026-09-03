using System;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때 마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    public GameObject SubBulletPrefab;

    public Transform FirePointTransform;

    public float CoolTime;
    private bool CoolDown = false;
    private float OriginCoolTime;

    private bool AutoMode = false;
    private string ObjectName;
    private void Start()
    {
        ObjectName = gameObject.name;
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
            GameObject subBullet = Instantiate(SubBulletPrefab);

            bullet.transform.position = FirePointTransform.position;
            switch (ObjectName)
            {
                case "FireLeftPoint":
                {
                    subBullet.transform.position = new Vector3(FirePointTransform.position.x - 0.05f, FirePointTransform.position.y-0.05f, FirePointTransform.position.z);
                    break;
                }
                case "FireRightPoint":
                {
                    subBullet.transform.position = new Vector3(FirePointTransform.position.x + 0.05f, FirePointTransform.position.y-0.05f, FirePointTransform.position.z);
                    break;
                }
            }
            
            CoolDown = true;
            CoolTime = OriginCoolTime;
        }
    }

    private void CheckCoolTime()
    {
        // 쿨타임 이라면
        if (CoolDown)
        {
            CoolTime -= Time.deltaTime;
        }

        if (CoolTime <= 0)
        {
            CoolDown = false;
        }
        
    }
}
