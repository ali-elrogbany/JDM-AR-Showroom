using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAudioManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float transitionOffset = 0.5f;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip starterSFX;
    [SerializeField] private AudioClip engineSound;

    [Header("References")]
    [SerializeField] private SFXSourceController sfxSourceController;

    [Header("Local Variables")]
    private bool isEngineRunning = false;
    private bool canToggleEngine = true;

    public void ToggleEngine()
    {
        if (!canToggleEngine)
        {
            return;    
        }

        if (isEngineRunning)
        {
            sfxSourceController.StopAudio();
            isEngineRunning = false;
            return;
        }
        else
        {
            StartCoroutine(StartEngine());
        }
    }

    private IEnumerator StartEngine()
    {
        canToggleEngine = false;

        sfxSourceController.PlayClip(starterSFX);

        yield return new WaitForSeconds(starterSFX.length - transitionOffset);

        sfxSourceController.PlayClip(engineSound);

        isEngineRunning = true;

        yield return new WaitForSeconds(1f);

        canToggleEngine = true;
    }
}
