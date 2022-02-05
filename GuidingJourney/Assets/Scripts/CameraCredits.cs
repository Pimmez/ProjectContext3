using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraCredits : MonoBehaviour
{
    public string sceneName;
    public void ExecuteEvent()
    {
        SceneManager.LoadScene(sceneName);
    }
}
