using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Text HightscoreText;

    private static Score instance;
    private static int score;

    void Start()
    {
        instance = this;
        score = 0;
        UpdateScore();
    }

    public static void AddScore()
    {
        score++;
        instance.UpdateScore();
    }

    public static int GetScore()
    {
        return score;
    }

    public void UpdateScore()
    {
        ScoreManager.UpdateScore();
        var hightScore = ScoreManager.GetHightscore();

        HightscoreText.text = "HIGHTSCORE\n"  + hightScore;
        ScoreText.text = "SCORE: " + score;
    }
}
