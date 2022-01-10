using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> allPlayerModels = new List<GameObject>();
    private void ChangeAnimalForm(int _range)
    {
        for (int i = 0; i < allPlayerModels.Count; i++)
        {
            allPlayerModels[i].SetActive(false);
            allPlayerModels[_range].SetActive(true);
        }
        GameManager.Instance.CheckAnimalActiveState();
    }

    private void OnEnable()
    {
        ScrollBehaviour.OnAnimalChangeEvent += ChangeAnimalForm;
    }

    private void OnDisable()
    {
        ScrollBehaviour.OnAnimalChangeEvent -= ChangeAnimalForm;
    }
}