using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject fadeImage;

    private void Awake()
    {
        fadeImage.SetActive(false);
    }

    private void ActivateStartFade()
    {
        anim.SetTrigger("StartFade");
        fadeImage.SetActive(true);
    }

    private void ActivateEndFade()
    {
        anim.SetTrigger("EndFade");
    }

    public void ResetFade()
    {
        fadeImage.SetActive(false);
        anim.SetTrigger("IdleFade");
    }

    private void OnEnable()
    {
        PlayerController.TestButtonEvent += ActivateStartFade;
        PlayerController.OnGrabEvent += ActivateEndFade;
    }

    private void OnDisable()
    {
        PlayerController.TestButtonEvent -= ActivateStartFade;
        PlayerController.OnGrabEvent -= ActivateEndFade;
    }
}