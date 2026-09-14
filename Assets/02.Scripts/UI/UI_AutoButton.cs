using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_AutoButton : MonoBehaviour
{
    // 버튼을 클릭하면 토글하고 싶다.
    // - 플레이어의 자동 이동
    // - 플레이어의 자동 공격
    [Header("on/off 스프라이트")]
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private Image _myImage;
    private bool _autoMode = false;
    private Player _player;
    private PlayerFire _playerFire;

    private void Start()
    {
        _myImage = GetComponent<Image>();
        _player = GameObject.FindAnyObjectByType<Player>();
        _playerFire = GameObject.FindAnyObjectByType<PlayerFire>();
    }

    public void AutoToggle()
    {
        _autoMode = !_autoMode;
        _playerFire.GetComponent<PlayerFire>().SetAuto(_autoMode);
        _player.GetComponent<PlayerMove>().enabled = !_autoMode;
        _player.GetComponent<PlayerAutoMove>().enabled = _autoMode;

        // 오토 모드에 따라 보여지는 이미지 스프라이트 교체
        // 삼항 연산자
        _myImage.sprite = _autoMode ? _onSprite : _offSprite;

        // todo: 버튼 클릭할 때 애니메이션 추가 + 사운드 추가
        // 애니메이션: 코드로 구현 약간 커졌다가 작아지게
        // 애니메이션 컴포넌트: UI_ButtonClick
        // 사운드: 일레븐랩스에서 버튼 클릭 공용 사운드 만들어서 적용
    }
}