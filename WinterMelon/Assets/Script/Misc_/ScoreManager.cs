using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public int GetScore() {
        return _score;
    }

    public void AddScore(int score) {
        _score += score * 1000;
        _scoreText.text = "Points: " + _score.ToString();
    }
}
