using TMPro;
using UnityEngine;

[System.Serializable]
public struct ScoreData {
    public int m_Score;
    public string m_Grade;
}

public class ScoreManager : MonoBehaviour {
    [SerializeField]
    private ScoreData[] m_ScoreData;
    [SerializeField]
    private int _score = 0;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI m_gradeText;

    public int GetScore() {
        return _score;
    }

    public void AddScore(int score) {
        _score += score * 1000;
        _scoreText.text = "Points: " + _score.ToString();
    }

    public void UpgradeFinalGrade() {
        for (int i = 0; i < m_ScoreData.Length; i++) {
            if (_score >= m_ScoreData[i].m_Score) {
                m_gradeText.text = "Grade: " + m_ScoreData[i].m_Grade;
                break;
            }
        }
    }
}
