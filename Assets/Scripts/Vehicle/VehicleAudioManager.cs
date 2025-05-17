using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAudioManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float transitionOffset = 0.5f;
    [SerializeField] private float fadeDuration = 0.5f;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip starterSFX;
    [SerializeField] private AudioClip engineSound;

    [Header("References")]
    [SerializeField] private SFXSourceController starterSFXController;
    [SerializeField] private SFXSourceController engineSFXController;

    [Header("Local Variables")]
    private bool isEngineRunning = false;
    private bool canToggleEngine = true;

    public void ToggleEngine()
    {
        if (!canToggleEngine) return;

        if (isEngineRunning)
        {
            engineSFXController.StopAudio();
            isEngineRunning = false;
        }
        else
        {
            StartCoroutine(StartEngine());
        }
    }

    private IEnumerator StartEngine()
    {
        canToggleEngine = false;

        // Start starter SFX
        starterSFXController.PlayClip(starterSFX);
        starterSFXController.SetVolume(1f);

        engineSFXController.PlayClip(engineSound, true);
        engineSFXController.SetVolume(0f);

        yield return new WaitForSeconds(starterSFX.length - transitionOffset);

        StartCoroutine(starterSFXController.FadeAudio(1f, 0f, fadeDuration));
        StartCoroutine(engineSFXController.FadeAudio(0f, 1f, fadeDuration));

        // Stop starter audio after fade
        yield return new WaitForSeconds(fadeDuration);
        starterSFXController.StopAudio();

        isEngineRunning = true;

        yield return new WaitForSeconds(1f);
        canToggleEngine = true;
    }
}
