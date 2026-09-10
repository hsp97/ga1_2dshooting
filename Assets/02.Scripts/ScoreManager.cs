using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 전역적으로 무엇을 뜻한지 안다.
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

    private void Awake()
    {
        // 늦게 생성된 매니저는 삭제 (단일성 보장)
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        Refresh();
    }
    public void AddScore(int score)
    {
        if (score <= 0) return;
        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }
        Refresh();
    }

    private void Refresh()
    {
        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Score: {_currentScore}";
    }
}
