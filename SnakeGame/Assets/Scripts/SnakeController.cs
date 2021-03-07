using UnityEngine;
using Assets.Objects;

public class SnakeController : MonoBehaviour
{
    public static Snake Snake;
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    [Range(0,1)]
    public static float gridMoveTimerMax = 0.25f;

    void Start()
    {
        Snake = new Snake(transform.gameObject);
        gridPosition = new Vector2Int(0, 0);
        gridMoveDirection = new Vector2Int(1, 0);
        gridMoveTimer = gridMoveTimerMax;
    }

    void Update()
    {
        switch (GameManager.StateGame)
        {
            case GameManager.State.Game:
                UpdateController();
                UpdateTimer();
                break;
            case GameManager.State.Bot:
                UpdateBotController();
                UpdateTimer();
                break;
        }
    }

    private void UpdateController()
    {
        if (Controller.ButtonPressed == Controller.Control.Up && gridMoveDirection.y == 0)
            InitializesDirection(0, 1);
        if (Controller.ButtonPressed == Controller.Control.Dawn && gridMoveDirection.y == 0)
            InitializesDirection(0, -1);
        if (Controller.ButtonPressed == Controller.Control.Left && gridMoveDirection.x == 0)
            InitializesDirection(-1, 0);
        if (Controller.ButtonPressed == Controller.Control.Right && gridMoveDirection.x == 0)
            InitializesDirection(1, 0);
    }

    private void UpdateBotController()
    {
        gridMoveDirection = Bot.GetDirection(gridPosition, MapUpdate.MapBounds);
    }

    private void InitializesDirection(int x, int y)
    {
        gridMoveDirection.x = x;
        gridMoveDirection.y = y;
    }

    private void UpdateTimer()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            CheckBounds();
            gridMoveTimer -= gridMoveTimerMax;
            Snake.UpdateMove(gridPosition, GetAngleFromDir(gridMoveDirection) + 180);
            SoundManager.PlaySound(SoundManager.Sound.SnakeMove);
        }
    }
    private void CheckBounds()
    {
        float x = (gridPosition.x < MapUpdate.MapBounds.x) ? 20
                : (gridPosition.x > MapUpdate.MapBounds.width) ? -20 
                : 0;
        float y = (gridPosition.y < MapUpdate.MapBounds.y) ? 20
                : (gridPosition.y > MapUpdate.MapBounds.height) ? -20
                : 0;
        gridPosition.x += (int)x;
        gridPosition.y += (int)y;
    }

    private float GetAngleFromDir(Vector2Int direction)
    {
        float n = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
