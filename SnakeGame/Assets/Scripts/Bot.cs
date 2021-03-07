using UnityEngine;

public static class Bot
{
    public static Vector2Int GetDirection(Vector2Int snakeHeadPosition, Rect mapSize)
    {
        if (snakeHeadPosition.y == mapSize.height)
        {
            if (snakeHeadPosition.x == mapSize.x)
                return new Vector2Int(0, -1);
            return new Vector2Int(-1, 0);
        }
        if (snakeHeadPosition.x % 2 == 0)
        {
            if (snakeHeadPosition.y == mapSize.y)
                return new Vector2Int(1, 0);
            return new Vector2Int(0, -1);
        }
        else if (snakeHeadPosition.y == mapSize.height - 1 
            && snakeHeadPosition.x != mapSize.width)
            return new Vector2Int(1, 0);
        return new Vector2Int(0, 1);
    }
}

