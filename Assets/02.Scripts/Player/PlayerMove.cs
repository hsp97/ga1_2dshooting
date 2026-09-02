using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Math;
using Object = System.Object;

public class PlayerMove : MonoBehaviour
{
    // 목적 : 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.
    
    // 필요 필드:
    public float Speed;

    public float Top;
    public float Bottom;
    public float Left;
    public float Right;

    private List<string> CommandList = new List<string>();
    private bool IsReplay = false;

    private float h = 0f;
    private float v = 0f;
    private Vector3 StartPosition;

    void Start()
    {
        // 게임 시작 시점의 위치를 변수에 저장
        StartPosition = transform.position;
    }
    
    // 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는: 별다은 설정이 없을 경우 가능한 많이
    private void Update()
    {
        if (CommandList.Count == 0)
        {
            StartPosition = transform.position;
        }
        
        // 1. 키보드 입력을 받는다.
        h = Input.GetAxis("Horizontal");  // 키보드 왼/오른쪽 입력 상태에 따라(서서히 증가 및 감소) -1f ~ 0 ~ 1f
        v = Input.GetAxis("Vertical");    // 키보드 위/아래 입력 상태에 따라(서서히 증가 및 감소) -1f ~ 0 ~ 1f
        string mutiply = "";
        // float h = Input.GetAxisRaw("Horizontal");   //곧바로 -1 0 1 반환
        // float v = Input.GetAxisRaw("Vertical");   //곧바로 -1 0 1 반환
        
        
        // 2. 키보드 입력에 따라 방향을 구한다.
        // 3. 방향과 속도에 따라 이동한다.
        if (Input.GetKey(KeyCode.R))
        {
            IsReplay = true;
            transform.position = StartPosition;
        }
        if (IsReplay)
        {
            string multiply = "";
            switch (CommandList[0])
            {
                case "speedUp":
                {
                    multiply = "speedUp";
                    CommandList.RemoveAt(0);
                    break;
                }
                case "speedDown":
                {
                    multiply = "speedDown";
                    CommandList.RemoveAt(0);
                    break;
                }   
            }
            
            ExcuteReplay(multiply);
        }
        else
        {
            SaveKey();
            if (Input.GetKey(KeyCode.E))
            {
                mutiply = "speedUp";
            }
        
            if (Input.GetKey(KeyCode.Q))
            {
                mutiply = "speedDown";
            }
            
            Move(h, v, mutiply);
                 
        }
    }

    private void Move(float h, float v, string mutiply)
    {
        if (transform.position.x <= Left)
        {
            transform.position = new Vector3(-Left, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= Right)
        {
            transform.position = new Vector3(-Right, transform.position.y, transform.position.z);
        }
        
        // 방향(벡터)를 계산해서
        // 게임에는 벡터라는 타입이 있다. 벡터는 크기와 방향을 의미한다.
        Vector2 direction = new Vector2(h, v);
        // = Vector2 direction = Vector2.left;
        
        // 대각선이 더 빠른것을 보간작업
        Vector2 normalizedSpeed = (direction * Speed).normalized; // 벡터의 길이를 1로 만들어주는것 (즉, 방향만 유지)

        if (mutiply == "speedUp")
        {
            normalizedSpeed *= 2;
        }

        if (mutiply == "speedDown")
        {
            normalizedSpeed /= 2;
        }
        
        transform.Translate( normalizedSpeed * Time.deltaTime);
        
        var positionY = transform.position;
        positionY.y = Math.Clamp(transform.position.y, Bottom, Top);
        transform.position = positionY;
    }

    private void SaveKey()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CommandList.Add("left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CommandList.Add("right");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            CommandList.Add("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            CommandList.Add("down");
        }
        if (Input.GetKey(KeyCode.E))
        {
            CommandList.Add("speedUp");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            CommandList.Add("speedDown");
        }
    } 
    private void ExcuteReplay(string multiply)
    {
        float h = 0f;
        float v = 0f;
        
        switch (CommandList[0])
        {
            case "left":
            {
                h = h + (-1) * Speed * Time.deltaTime;
                Move(h,v,multiply);
                break;
            }
            case "right":
            {
                h = h + (1) * Speed * Time.deltaTime;
                Move(h,v,multiply);
                break;
            }
            case "up":
            {
                v = 1;
                Move(h,v,multiply);
                break;
            }
            case "down":
            {
                v = -1;
                Move(h,v,multiply);
                break;
            }
        }
        
        CommandList.RemoveAt(0);
        if (CommandList.Count <= 1)
        {
            IsReplay = false;            
        }
        
    }
    
    // 새로운 위치 = 현재 위치 + (방향 * 속력 * 시간)
    // transform.position = transform.position + (Vector3)direction * Speed * Time.deltaTime;
    // transform.position += (Vector3)direction * Speed * Time.deltaTime;

    // 키 입력을 받으면
    /*
    if (Input.GetKey(KeyCode.LeftArrow))
    {
        // 이동한다.
        // 속도 =  방향 * 속력

        // 0.06 -> 하드 코딩 -> 헷갈리는 숫자 -> 매직넘버링
        // 매직넘버란 : 보는 사람에 따라 의미가 달라질 수 있는 헷갈리는 숫자

        transform.Translate(direction * (Speed * Time.deltaTime));
        // deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS로 반환
    }
    */
}
