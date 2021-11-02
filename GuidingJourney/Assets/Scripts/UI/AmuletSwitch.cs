using System.Collections.Generic;
using UnityEngine;

public class AmuletSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> images = new List<GameObject>();
    private bool isActive = false;
    public void OnAmuletClick()
    {
        isActive = !isActive;
        foreach (GameObject image in images)
        {
            image.SetActive(isActive);
        }
    }
}