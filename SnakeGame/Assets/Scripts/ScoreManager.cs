using UnityEngine;

public static class ScoreManager 
{
    private static readonly string key = "highscore";
    public static bool HightscoreBroken { get; private set; }


    public static void UpdateScore()
    {
        CheckFirstScore(); 
        var score = Score.GetScore();
        var highscore = PlayerPrefs.GetInt(key);
        if (highscore >= score)
        {
            HightscoreBroken = false;
            return;
        }
        PlayerPrefs.SetInt("highscore", score);
        PlayerPrefs.Save();
        HightscoreBroken = true;
    }

    private static void CheckFirstScore()
    {
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetInt(key, 0);
    }

    public static int GetHightscore()
    {
        return PlayerPrefs.GetInt(key);
    }
}
