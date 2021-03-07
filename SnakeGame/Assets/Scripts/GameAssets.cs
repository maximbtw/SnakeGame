using UnityEngine;
using System;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    private void Awake()
    {
        i = this;
    }

    public Sprite SnakeHeadSprite;
    public Sprite SnakeBoneSprite;
    public Sprite SnakeBoneRotateSprite1;
    public Sprite SnakeBoneRotateSprite2;
    public Sprite AppleSprite;

    public SoundAudioClip[] soundAudioClipArray;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
