using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class Bot_Test
{
    private readonly Rect MapSize = new Rect(-10, -5, 9, 14);
    [Test] 
    public void LeftUpAngle()
    {
        var snakeHeadPosition = new Vector2Int(-10, 14);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(0, -1));
    }

    [Test]
    public void LeftDawnAngle()
    {
        var snakeHeadPosition = new Vector2Int(-10, -5);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(1, 0));
    }

    [Test]
    public void PrevTop()
    {
        var snakeHeadPosition = new Vector2Int(-9, 13);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(1, 0));
    }

    [Test]
    public void LeftDawnNotOwn()
    {
        var snakeHeadPosition = new Vector2Int(-9, -5);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(0, 1));
    }

    [Test]
    public void LeftUpOwn()
    {
        var snakeHeadPosition = new Vector2Int(-10, 13);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(0, -1));
    }

    [Test]
    public void UpBound()
    {
        var snakeHeadPosition = new Vector2Int(6, 14);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(-1, 0));
    }

    [Test]
    public void RightUpBound()
    {
        var snakeHeadPosition = new Vector2Int(9, 13);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(0, 1));
    }

    [Test]
    public void RightUpAngle()
    {
        var snakeHeadPosition = new Vector2Int(9, 14);

        var result = Bot.GetDirection(snakeHeadPosition, MapSize);
        Assert.AreEqual(result, new Vector2Int(-1, 0));
    }

    [Test]
    public void MoveSnake()
    {
        var snakeHeadPosition = new Vector2Int(9, 12);

        for(int i = 0; i < 3; i++)
        {
            snakeHeadPosition+= Bot.GetDirection(snakeHeadPosition, MapSize);
            if(i==0) Assert.AreEqual(new Vector2Int(9, 13), snakeHeadPosition);
            if (i == 1) Assert.AreEqual(new Vector2Int(9, 14), snakeHeadPosition);
            if (i == 2) Assert.AreEqual(new Vector2Int(8, 14), snakeHeadPosition);
        }
    }
}
