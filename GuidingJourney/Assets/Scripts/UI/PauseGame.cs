using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject scrollObject;
    [SerializeField] private GameObject pauseObject;

    private bool isPaused = false;

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
        SceneManager.LoadScene(_scene);
    }
}