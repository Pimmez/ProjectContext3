using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerScript : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private VideoPlayer vid;

    [Header("Settings")]
    [SerializeField] private bool isLonelyScene = false;
    [SerializeField] private string sceneName;

    [Header("EDITOR VALUE")]
    [SerializeField] private int firstTimeCheck = 0;

    private void Awake()
    {
        firstTimeCheck = PlayerPrefs.GetInt("FirstTimeCheck");
    }

    private void Start()
    {
        vid.loopPointReached += CheckOver;
    }

    private void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        firstTimeCheck = 1;
        PlayerPrefs.SetInt("FirstTimeCheck", firstTimeCheck);

        if (isLonelyScene)
        {
            SceneManager.LoadScene(sceneName);
        }
        //Debug.Log("Video Is Over");
    }

    private void Update()
    {
        if(Input.anyKey && firstTimeCheck == 1)
        {
            if (isLonelyScene)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}