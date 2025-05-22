using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private GameObject pauseIcon;
    [SerializeField] private GameObject pauseScreenPanel;

    [Header("Button References")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button mainMenuButton;

    [Header("Slider References")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Local Variables")]
    private bool isPauseToggled = false;

    private void Awake()
    {
        PopulateButtonListeners();
        PopulateSliderListeners();  
    }

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            musicSlider.value = AudioManager.instance.GetMusicVolume();
            sfxSlider.value = AudioManager.instance.GetSFXVolume();
        }  
    }

    private void PopulateButtonListeners()
    {
        pauseButton.onClick.AddListener(() => OnTogglePause(true));
        backButton.onClick.AddListener(() => OnTogglePause(false));
        mainMenuButton.onClick.AddListener(() => OnLoadMainMenu());
    }

    private void PopulateSliderListeners()
    {
        musicSlider.onValueChanged.AddListener((float volume) => SetMusicVolume());
        sfxSlider.onValueChanged.AddListener((float volume) => SetSFXVolume());
    }

    public void OnTogglePause(bool isToggled)
    {
        isPauseToggled = isToggled;

        pauseIcon.SetActive(!isPauseToggled);
        pauseScreenPanel.SetActive(isPauseToggled);
    }

    public void OnLoadMainMenu()
    {
        SceneManager.LoadScene(0);
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
