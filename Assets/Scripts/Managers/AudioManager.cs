using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicAudioSource;

    private List<SFXSourceController> sfxSourceControllers;

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

        foreach (SFXSourceController sfxManager in sfxSourceControllers)
        {
            sfxManager.SetVolume(volume);
        }
    }

    public void AddSFXSourceController(SFXSourceController sfxSourceController)
    {
        sfxSourceControllers.Add(sfxSourceController);
    }

    public void RemoveSFXSourceController(SFXSourceController sfxSourceController)
    {
        if (sfxSourceControllers.Contains(sfxSourceController))
        {
            sfxSourceControllers.Remove(sfxSourceController);
        }
    }

    public void ClearSFXSourceControllers()
    {
        sfxSourceControllers.Clear();
    }
}
