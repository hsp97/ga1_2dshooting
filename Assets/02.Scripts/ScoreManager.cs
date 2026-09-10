using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 전역적으로 무엇을 뜻하는지 안다.
    // 인스턴스(생성된 객체) 가 하나임을 보장한다. 그 누구가 한 개 라는것을 안다.
    // static(정적)
    private static ScoreManager _instance = null;

    public static ScoreManager Instance => _instance;
    // 관리: 특정 데이터에 대한 무결성과 생성, 읽기, 수정, 삭제 등과 관련된 로직
    private int _bestScore = 0;
    private int _currentScore = 0;
    // UI 책임 추가 (텍스트메시 프로 참조)
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;
    private const string SaveKey = "BestScore";
    private void Awake()
    {
        // 늦게 생성된 매니저는 삭제 (단일성 보장)
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    {
        // 입력: Input.
        // 저장/불러오기: PlayerPrefs
        /*
        if (PlayerPrefs.HasKey(SaveKey))
        {
            _bestScore = PlayerPrefs.GetInt(SaveKey);
        }
        */
        _bestScore = PlayerPrefs.GetInt(SaveKey, 0);
        Refresh();
    }
    public void AddScore(int score)
    {
        if (score <= 0) return;
        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            // 저장: PlayerPrefs.Set~ 시리즈를 이용해서 int/float/string 을 저장가능하다.
            // 내 컴퓨터 어딘가에 저장이 된다.
            PlayerPrefs.SetInt(SaveKey, _bestScore);
            PlayerPrefs.Save();
        }
        Refresh();
    }

    private void Refresh()
    {
        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Score: {_currentScore}";
    }
}
