using UnityEngine;
using System.Linq;

public class MapUpdate : MonoBehaviour
{
    public static Rect MapBounds = new Rect(-10, -5, 9, 14);

    public GameObject Snake;
    public GameObject Apple;

    void Start()
    {
        Snake.transform.position = new Vector3(0.5f, 4.5f);
        SpawnApple();
    }

    void Update()
    {
        GameManager.UpdateStateGame();
        CheckAppleIsEaten(Apple.transform.position, Snake.transform.position);
    }

    private void CheckAppleIsEaten(Vector3 applePosition, Vector3 snakePosition)
    {
        if (!applePosition.Equals(snakePosition)) return;
        SoundManager.PlaySound(SoundManager.Sound.EatApple);
        if (Score.GetScore() != 400) SpawnApple();
        Score.AddScore();
        SnakeController.Snake.AddBone();
    }


    private void SpawnApple()
    {
        int x = Random.Range((int)MapBounds.x, (int)MapBounds.width + 1);
        int y = Random.Range((int)MapBounds.y, (int)MapBounds.height + 1);
        var applePosition = new Vector3(x + 0.5f, y + 0.5f);
        if (SnakeController.Snake.GetFullSnakePosition().Any(p => p.Equals(applePosition)))
            SpawnApple();
        else Apple.transform.position = applePosition;
    }
}
