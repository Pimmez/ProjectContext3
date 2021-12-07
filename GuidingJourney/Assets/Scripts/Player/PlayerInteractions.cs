using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static Action StartFadeEvent;
    public static Action EndFadeEvent;

    private Vector3 newLocation;
    [SerializeField] CharacterController characterController;
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        newLocation = new Vector3(-8, this.transform.position.y, 110);
    }

    private void OnCrawl()
    {
        Debug.Log("PlayerInteractions::OnCrawlBegin");

        characterController.enabled = false;

        //Do Fox Crawl Animation
        anim.SetTrigger("isCrawling");

        Debug.Log("PlayerInteractions::AnimSetBool");

       // anim.SetBool("isCrawling", false);

        //Teleport Fox
            
        //End Fade      
    }

    public void CrawlToFade()
    {
        if (StartFadeEvent != null)
        {
            StartFadeEvent();
        }
    }

    public void FadeToCrawl()
    {
        this.transform.position = newLocation;

        anim.SetTrigger("isIdle");

        characterController.enabled = true;
        if (EndFadeEvent != null)
        {
            EndFadeEvent();
        }
    }

    private void OnEnable()
    {
        PlayerController.OnCrawlEvent += OnCrawl;
    }

    private void OnDisable()
    {
        PlayerController.OnCrawlEvent -= OnCrawl;
    }
}