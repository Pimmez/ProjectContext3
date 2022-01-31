using Extensions.Generics.Singleton;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class GameManager : GenericSingleton<GameManager, GameManager>
{
    [Header("Component References")]
    [SerializeField] private GameObject fox;
    [SerializeField] private GameObject dove;
    [SerializeField] private GameObject pressToMove = null;
    public GameObject dialogueManager = null;
    public GameObject settingsButton;
    public GameObject isFoxActive;
    public GameObject isDoveActive;
    public GameObject parentObject;
    [SerializeField] private AudioClip backgroundMusic = null;
    public CinemachineVirtualCamera cin;

    [Header("Settings")]
    [SerializeField] private List<GameObject> ChangeableModels = new List<GameObject>();
    public bool isHoldingObject = false;
    public bool isCrawling = false;
    public bool isGamePaused;
    public bool isLetterFound = false;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(backgroundMusic);
        pressToMove.SetActive(true);
    }

    private void Update()
    {
        if(isDoveActive.activeSelf)
        {
            cin.Follow = isDoveActive.transform;
        }
        else
        {
            cin.Follow = parentObject.transform;
        }

        if (Input.anyKey)
        {
            pressToMove.SetActive(false);
        }
    }

    public void CheckAnimalActiveState()
    {
        if (fox.activeSelf)
        {
            for (int i = 0; i < ChangeableModels.Count; i++)
            {
                ChangeableModels[i].layer = 0;
            }
            Debug.Log("Change to defaut layer");
        }
        else if(dove.activeSelf)
        {
            for (int i = 0; i < ChangeableModels.Count; i++)
            {
                ChangeableModels[i].layer = 6;
            }
            Debug.Log("Change to flying layer");
        }
    }
}