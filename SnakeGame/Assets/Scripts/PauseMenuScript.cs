using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    private static PauseMenuScript instance;
    public static GameManager.State PrevStateGame;

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
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void HideStatic()
    {
        instance.Hide();
    }
}
