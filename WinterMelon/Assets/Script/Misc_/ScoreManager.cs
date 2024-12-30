using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;

    public int GetScore() {
        return _score;
    }

    public void AddScore(int score) {
        _score += score;
    }
}
