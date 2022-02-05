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
    [SerializeField] private bool nextVideo = false;

    [SerializeField] private string sceneName;
    [SerializeField] private string cutsceneName;
    [SerializeField] private string cutsceneNameExtra;

    [Header("EDITOR VALUE")]
    [SerializeField] private int firstTimeCheck = 0;

    private void Awake()
    {
        firstTimeCheck = PlayerPrefs.GetInt("FirstTimeCheck");
        vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, cutsceneName);
        vid.Play();
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

        if(nextVideo)
        {
            NextVideo();
        }
        //Debug.Log("Video Is Over");
    }

    private void NextVideo()
    {
        vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, cutsceneNameExtra);
        vid.Play();

        vid.loopPointReached += GoToCredits;

    }

    private void GoToCredits(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("CreditsScene");

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