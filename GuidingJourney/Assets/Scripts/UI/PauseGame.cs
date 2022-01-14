using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private GameObject scrollObject;
    [SerializeField] private GameObject pauseObject;
    [SerializeField] private GameObject confirmationObject;

    [Header("Audio References")]
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider allVolumeSlider;
    [SerializeField] private Slider backgroundVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    //Privates
    private bool isPaused = false;

    private void Awake()
    {
        LoadQualityValues();
        LoadAudioValues();
    }

    public void PauseOnOff()
    {
        isPaused = !isPaused;
        scrollObject.SetActive(!isPaused);
        pauseObject.SetActive(isPaused);
        
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ReturnToMenu(string _scene)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(_scene);
    }

    public void ConfirmToMenu()
    {
        pauseObject.SetActive(false);
        confirmationObject.SetActive(true);
    }

    public void CloseConfirmPanel()
    {
        pauseObject.SetActive(true);
        confirmationObject.SetActive(false);
    }

    public void SetQualityLow(bool _qualityIndex)
    {
        if (_qualityIndex)
        {
            QualitySettings.SetQualityLevel(0);
            PlayerPrefs.SetInt("QualitySettings", 0);
            LoadQualityValues();
        }
    }

    public void SetQualityMedium(bool _qualityIndex)
    {
        if (_qualityIndex)
        {
            QualitySettings.SetQualityLevel(1);
            PlayerPrefs.SetInt("QualitySettings", 1);
            LoadQualityValues();
        }
    }

    public void SetQualityHigh(bool _qualityIndex)
    {
        if (_qualityIndex)
        {
            QualitySettings.SetQualityLevel(2);
            PlayerPrefs.SetInt("QualitySettings", 2);
            LoadQualityValues();
        }
    }

    public void AllAudioSettings(float _volume)
    {
        mainMixer.SetFloat("AllVolume", _volume);
        PlayerPrefs.SetFloat("MainVolume", _volume);
        LoadAudioValues();
    }

    public void SoundSettings(float _volume)
    {
        mainMixer.SetFloat("MainVolume", _volume);
        PlayerPrefs.SetFloat("BackgroundVolume", _volume);
        LoadAudioValues();
    }

    public void SFXSettings(float _volume)
    {
        mainMixer.SetFloat("SFXVolume", _volume);
        PlayerPrefs.SetFloat("SFXVolume", _volume);
        LoadAudioValues();
    }

    private void LoadAudioValues()
    {
        float allVolumeValue = PlayerPrefs.GetFloat("MainVolume");
        allVolumeSlider.value = allVolumeValue;

        float backgroundVolumeValue = PlayerPrefs.GetFloat("BackgroundVolume");
        backgroundVolumeSlider.value = backgroundVolumeValue;

        float sfxVolumeValue = PlayerPrefs.GetFloat("SFXVolume");
        sfxVolumeSlider.value = sfxVolumeValue;
    }

    private void LoadQualityValues()
    {
        int qualityValue = PlayerPrefs.GetInt("QualitySettings");
        QualitySettings.SetQualityLevel(qualityValue);
    }
}