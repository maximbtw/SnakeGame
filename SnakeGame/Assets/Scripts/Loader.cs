using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Objects;

public class Loader : MonoBehaviour
{
    public void PlaySoundButtonClick()
    {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void SceneWithBot(string nameScene)
    {
        ChangeScene(nameScene);
        GameManager.StateGame = GameManager.State.Bot;
    }

    public void SceneWithoutBot(string nameScene)
    {
        ChangeScene(nameScene);
        GameManager.StateGame = GameManager.State.Game;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void PauseStateSwich()
    {
        if (GameManager.StateGame == GameManager.State.Pause)
        {
            GameManager.StateGame = PauseMenuScript.PrevStateGame;
            PauseMenuScript.HideStatic();
        }
        else
        {
            PauseMenuScript.PrevStateGame = GameManager.StateGame;
            GameManager.StateGame = GameManager.State.Pause;
        }
    }
}
