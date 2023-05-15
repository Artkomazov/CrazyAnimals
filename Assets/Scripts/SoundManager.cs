using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;

    public void SetMusicEnablet(bool isON)
    {
        Music.enabled = isON;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
