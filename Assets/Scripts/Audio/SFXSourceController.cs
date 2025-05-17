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
  }

  public void SetVolume(float volume)
  {
    sfxSource.volume = volume;
  }

  public void PlayClip(AudioClip audioClip)
  {
    PlayClip(audioClip, false);
  }

  public void PlayClip(AudioClip audioClip, bool loop)
  {
    sfxSource.clip = audioClip;
    sfxSource.loop = loop;

    sfxSource.Play();
  }

  public void StopAudio()
  {
    sfxSource.Stop();
  }

  public IEnumerator FadeAudio(float startVolume, float endVolume, float duration)
  {
      float elapsedTime = 0f;

      while (elapsedTime < duration)
      {
          sfxSource.volume = Mathf.Lerp(startVolume, endVolume, elapsedTime / duration);
          elapsedTime += Time.deltaTime;
          yield return null;
      }

      sfxSource.volume = endVolume;
  }
}
