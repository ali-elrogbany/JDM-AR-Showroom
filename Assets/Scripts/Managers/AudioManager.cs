using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicVolume(float volume)
    {
        if (volume > 1 || volume < 0)
            return;

        musicAudioSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        if (volume > 1 || volume < 0)
            return;

        sfxAudioSource.volume = volume;
    }
}
