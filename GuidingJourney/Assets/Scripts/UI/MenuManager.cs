using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuHUD = null;
    [SerializeField] private GameObject SettingsHUD = null;
    [SerializeField] private GameObject CreditsHUD = null;


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
}