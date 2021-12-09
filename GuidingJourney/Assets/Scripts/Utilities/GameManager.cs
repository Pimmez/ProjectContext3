using Extensions.Generics.Singleton;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : GenericSingleton<GameManager, GameManager>
{
    [Header("Component References")]
    [SerializeField] private GameObject fox;
    [SerializeField] private GameObject dove;

    [Header("Settings")]
    [SerializeField] private List<GameObject> ChangeableModels = new List<GameObject>();
    public bool isGamePaused; 

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