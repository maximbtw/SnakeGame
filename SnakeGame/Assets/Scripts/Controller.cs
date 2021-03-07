using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public enum Control { Left, Right, Up, Dawn,};
    private static Controller instance;
    public static Control ButtonPressed = Control.Right;
    public Slider Slider;

    void Start()
    {
        instance = this;
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        if (GameManager.StateGame == GameManager.State.Bot)
            Slider.gameObject.SetActive(true);
        else Slider.gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void HideStatic()
    {
        instance.Hide();
    }

    public static void UpdateGridMoveTimerMax()
    {
        SnakeController.gridMoveTimerMax = Controller.instance.Slider.value;
    }

    public void PressedButton(string nameButton)
    {
        switch (nameButton)
        {
            case "Left":
                Controller.ButtonPressed = Control.Left;
                break;
            case "Right":
                Controller.ButtonPressed = Control.Right;
                break;
            case "Up":
                Controller.ButtonPressed = Control.Up;
                break;
            case "Dawn":
                Controller.ButtonPressed = Control.Dawn;
                break;
        }
    }
}
