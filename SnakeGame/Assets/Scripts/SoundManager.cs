using UnityEngine;

public static class SoundManager 
{
    public enum Sound
    {
        EatApple,
        SnakeMove,
        SnakeDeath,
        SnakeDeathNewHightscore,
        ButtonClick,
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(var soundAudioClip in GameAssets.i.soundAudioClipArray)
            if (soundAudioClip.sound == sound)
                return soundAudioClip.audioClip;
        Debug.Log("Sound " + sound + " not foand!");
        return null;
    }
}
