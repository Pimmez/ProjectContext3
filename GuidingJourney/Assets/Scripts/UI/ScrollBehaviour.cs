using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBehaviour : MonoBehaviour
{
    public static Action<int> OnAnimalChangeEvent;
    [SerializeField] private Sprite scrollClosedImage, scrollOpenImage;
    [SerializeField] private GameObject scroll;
    
    private bool isScrollActive = false;
    private Image scrollImage;

    private void Awake()
    {
        scrollImage = GetComponent<Image>();    
    }

    //Enables and Disables the scroll(image) when the button is clicked
    public void OpenScroll()
    {
        isScrollActive = !isScrollActive;
        ChangeScrollImage();

        //Needs animation in the future
    }

    private void ChangeScrollImage()
    {
        scroll.SetActive(isScrollActive);

        if (isScrollActive)
        {
            scrollImage.sprite = scrollOpenImage;
        }
        else
        {
            scrollImage.sprite = scrollClosedImage;
        }
    }

    public void FoxActivation()
    {
        if (OnAnimalChangeEvent != null)
        {
            OnAnimalChangeEvent(0);
        }
        isScrollActive = false;
        ChangeScrollImage();
    }

    public void DoveActivation()
    {
        if(OnAnimalChangeEvent != null)
        {
            OnAnimalChangeEvent(1);
        }
        isScrollActive = false;
        ChangeScrollImage();
    }
}