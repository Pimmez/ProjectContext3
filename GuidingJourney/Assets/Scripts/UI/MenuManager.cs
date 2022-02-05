using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class MenuManager : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private GameObject MenuHUD = null;
    [SerializeField] private GameObject SettingsHUD = null;
    [SerializeField] private GameObject CreditsHUD = null;
    public RenderPipelineAsset[] qualitylevels = null;
    public Dropdown dropdown = null;

    [Header("Audio References")]
    [SerializeField] private AudioMixer mainMixer = null;
    [SerializeField] private Slider allVolumeSlider = null;
    [SerializeField] private Slider backgroundVolumeSlider = null;
    [SerializeField] private Slider sfxVolumeSlider = null;
    [SerializeField] private AudioSource sfxSource = null;
    [SerializeField] private AudioSource backgroundSource = null;
    [SerializeField] private AudioClip backgroundClip = null;

    private void Start()
    {
        if(dropdown != null)
        {
            dropdown.value = QualitySettings.GetQualityLevel();
        }

        if(mainMixer != null)
        {
            LoadAudioValues();
        }
        
        SoundManager.Instance.PlayMusic(backgroundClip);
        //LoadQualityValues();
    }
    public void ChangeQualityLevels(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = qualitylevels[value];
    }

    public void SceneChanger(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void OnQuitGame()
    {
        Application.Quit();
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
    public void OpenFACEBOOK()
    {
        Application.OpenURL("https://www.facebook.com/PBINederland/");
    }
    public void OpenTWITTER()
    {
        Application.OpenURL("https://twitter.com/PBINederland");
    }
    public void OpenDONATION()
    {
        Application.OpenURL("https://www.peacebrigades.nl/doe-mee/doneren/");
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
        if (_volume <= -39f)
        {
            sfxSource.mute = true;
            backgroundSource.mute = true;
        }
        else
        {
            sfxSource.mute = false;
            backgroundSource.mute = false;
        }

        mainMixer.SetFloat("AllVolume", _volume);
        PlayerPrefs.SetFloat("MainVolume", _volume);
        LoadAudioValues();
    }

    public void SoundSettings(float _volume)
    {
        if (_volume <= -39f)
        {
            backgroundSource.mute = true;
        }
        else
        {
            backgroundSource.mute = false;
        }

        mainMixer.SetFloat("MainVolume", _volume);
        PlayerPrefs.SetFloat("BackgroundVolume", _volume);
        LoadAudioValues();
    }

    public void SFXSettings(float _volume)
    {
        if (_volume <= -39f)
        {
            sfxSource.mute = true;
        }
        else
        {
            sfxSource.mute = false;
        }

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