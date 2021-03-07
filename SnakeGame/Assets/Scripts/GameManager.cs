using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public enum State
    {
        Bot,
        Game,
        Pause,
        Dead
    }

    public static State StateGame = State.Game;

    public static void UpdateStateGame()
    {
        switch (StateGame)
        {
            case State.Bot:
                Controller.ShowStatic();
                break;
            case State.Game:
                Controller.ShowStatic();
                break;
            case State.Pause:
                PauseMenuScript.ShowStatic();
                Controller.HideStatic();
                break;
            case State.Dead:
                GameOverWindow.ShowStatic();
                Controller.HideStatic();
                break;
        }
    }
}
