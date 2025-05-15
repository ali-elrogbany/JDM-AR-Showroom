using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSourceController : MonoBehaviour
{
    private AudioSource sfxSource;

    private void Awake()
    {
      sfxSource = GetComponent<AudioSource>();
      
      sfxSource.playOnAwake = false;
      sfxSource.loop = false;

      if (AudioManager.instance != null && sfxSource != null)
      {
        AudioManager.instance.AddSFXSourceController(this);
      }  
    }

    private void OnDestroy()
    {
      if (AudioManager.instance != null)
      {
        AudioManager.instance.RemoveSFXSourceController(this);
      }  
    }

    public void SetVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void PlayClip(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }
}
