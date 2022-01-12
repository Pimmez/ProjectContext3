using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChanger(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }
    
    public void OpenURL()
    {
        Application.OpenURL("https://www.peacebrigades.nl/");
    }
}