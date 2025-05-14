using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject settingsCanvas;

    [Header("Sliders")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            if (musicSlider != null)
            {
                AudioManager.instance.SetMusicVolume(musicSlider.value);
            }

            if (sfxSlider != null)
            {
                AudioManager.instance.SetSFXVolume(sfxSlider.value);
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleSettings(bool isActive)
    {
        mainCanvas.SetActive(!isActive);
        settingsCanvas.SetActive(isActive);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void SetMusicVolume()
    {
        if (AudioManager.instance != null && musicSlider != null)
        {
            AudioManager.instance.SetMusicVolume(musicSlider.value);
        }
    }

    public void SetSFXVolume()
    {
        if (AudioManager.instance != null && sfxSlider != null)
        {
            AudioManager.instance.SetSFXVolume(sfxSlider.value);
        }
    }
}
