using UnityEngine.UI;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;
    private bool active = false;

    public Text TextNewHightscore;
    public Text TextHightscore;

    void Start()
    {
        instance = this;
        Hide();
    }

    private void Show()
    {
        if (active) return;
        active = true;
        gameObject.SetActive(true);
        ShowText();
    }


    private void ShowText()
    {
        var hightscore = ScoreManager.GetHightscore();
        if (ScoreManager.HightscoreBroken)
        {
            TextHightscore.gameObject.SetActive(false);
            TextNewHightscore.gameObject.SetActive(true);
            TextNewHightscore.text = "NEW HIGHTSCORE!\n" + hightscore;
            SoundManager.PlaySound(SoundManager.Sound.SnakeDeathNewHightscore);
        }
        else
        {
            TextNewHightscore.gameObject.SetActive(false);
            TextHightscore.gameObject.SetActive(true);
            TextHightscore.text = "YOU HIGHTSCORE!\n" + hightscore;
            SoundManager.PlaySound(SoundManager.Sound.SnakeDeath);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        active = false;
    }

    public static void ShowStatic()
    {
        instance.Show();
    }
}
