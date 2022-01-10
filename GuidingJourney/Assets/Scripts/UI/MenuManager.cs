using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuHUD = null;
    [SerializeField] private GameObject SettingsHUD = null;
    [SerializeField] private GameObject CreditsHUD = null;

    [SerializeField] private AudioMixer mainMixer;

    [SerializeField] private Slider allVolumeSlider;
    [SerializeField] private Slider backgroundVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;


    private void Start()
    {
        LoadAudioValues();
        LoadQualityValues();
    }

    public void SceneChanger(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void Settings()
    {
        MenuHUD.SetActive(false);
        SettingsHUD.SetActive(true);
    }

    public void Credits()
    {
        MenuHUD.SetActive(false);
        CreditsHUD.SetActive(true);
    }

    public void BackToMenu()
    {
        MenuHUD.SetActive(true);
        SettingsHUD.SetActive(false);
        CreditsHUD.SetActive(false);
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.peacebrigades.nl/");
    }

    public void SetQualityLow(bool _qualityIndex)
    {
        if(_qualityIndex)
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