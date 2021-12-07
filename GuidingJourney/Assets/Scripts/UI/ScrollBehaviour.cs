using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBehaviour : MonoBehaviour
{
    public static Action<int> OnAnimalChangeEvent;

    [SerializeField] private GameObject scroll;
    private bool isScrollActive = false;
   
    //Enables and Disables the scroll(image) when the button is clicked
    public void OpenScroll()
    {
        isScrollActive = !isScrollActive;
        scroll.SetActive(isScrollActive);

        //Needs animation in the future
    }

    public void FoxActivation()
    {
        if (OnAnimalChangeEvent != null)
        {
            OnAnimalChangeEvent(0);
        }
    }

    public void DoveActivation()
    {
        if(OnAnimalChangeEvent != null)
        {
            OnAnimalChangeEvent(1);
        }
    }
}