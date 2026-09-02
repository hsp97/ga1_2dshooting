using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 목적 : 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.
    
    // 필요 필드:
    public float Speed;

    public float Top;
    public float Bottom;
    public float Left;
    public float Right;
    
    // 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는: 별다은 설정이 없을 경우 가능한 많이
    private void Update()
    {
        // 1. 키보드 입력을 받는다.
        float h = Input.GetAxis("Horizontal");  // 키보드 왼/오른쪽 입력 상태에 따라(서서히 증가 및 감소) -1f ~ 0 ~ 1f
        float v = Input.GetAxis("Vertical");    // 키보드 위/아래 입력 상태에 따라(서서히 증가 및 감소) -1f ~ 0 ~ 1f

        // float h = Input.GetAxisRaw("Horizontal");   //곧바로 -1 0 1 반환
        // float v = Input.GetAxisRaw("Vertical");   //곧바로 -1 0 1 반환

        Debug.Log($"{h}, {v}");
        
        // 2. 키보드 입력에 따라 방향을 구한다.
        // 3. 방향과 속도에 따라 이동한다.
        
        if (transform.position.y >= Top)
        {
            if (v > 0)
            {
                v = 0;
            }
        }
        else if (transform.position.y <= Bottom)
        {
            if (v < 0)
            {
                v = 0;
            }
        }
        else if(transform.position.x >= Right)
        {
            if (h > 0)
            {
                h = 0;
            }
        }
        else if (transform.position.x <= Left)
        {
            if (h < 0)
            {
                h = 0;
            }
        }
        
        // 방향(벡터)를 계산해서
        // 게임에는 벡터라는 타입이 있다. 벡터는 크기와 방향을 의미한다.
        Vector2 direction = new Vector2(h, v);
        // = Vector2 direction = Vector2.left;
        
        // 대각선이 더 빠른것을 보간작업
        Vector2 normalizedSpeed = (direction * Speed).normalized; // 벡터의 길이를 1로 만들어주는것 (즉, 방향만 유지)
        
        transform.Translate( normalizedSpeed * Time.deltaTime);
        
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
}
