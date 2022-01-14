using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBehaviour : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Sprite scrollClosedImage, scrollOpenImage;
    [SerializeField] private GameObject scroll = null;

    //Action Events
    public static Action<int> OnAnimalChangeEvent;

    //Privates
    private bool isScrollActive = false;
    private Image scrollImage;

    private void Awake()
    {
        scrollImage = GetComponent<Image>();
    }

    //Enables and Disables the scroll(image) when the button is clicked
    public void OpenScroll()
    {
        if (!GameManager.Instance.isHoldingObject && !GameManager.Instance.isCrawling)
        {
            isScrollActive = !isScrollActive;
            ChangeScrollImage();
            //Needs animation in the future
        }
        else
        {
            return;
        }
    }

    private void ChangeScrollImage()
    {
        scroll.SetActive(isScrollActive);
        GameManager.Instance.settingsButton.SetActive(!isScrollActive);

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
        if (OnAnimalChangeEvent != null)
        {
            OnAnimalChangeEvent(1);
        }
        isScrollActive = false;
        ChangeScrollImage();
    }
}