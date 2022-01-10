using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static Action StartFadeEvent;
    public static Action EndFadeEvent;

    [SerializeField] CharacterController characterController;
    [SerializeField] private Animator anim;
    private Transform crawlToLocation = null;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
        this.transform.position = new Vector3(crawlToLocation.position.x, 43, crawlToLocation.position.z);
        GameManager.Instance.isGamePaused = false;

        anim.SetTrigger("isIdle");

        characterController.enabled = true;
        if (EndFadeEvent != null)
        {
            EndFadeEvent();
            //crawlToLocation = null;
        }
    }

    private void Interact(Transform _location)
    {
        crawlToLocation = _location;

        GameManager.Instance.isGamePaused = true;

        characterController.enabled = false;

        //Do Fox Crawl Animation
        anim.SetTrigger("isCrawling");
    }

    private void OnEnable()
    {
        CrawlableObject.SendLocationEvent += Interact;
    }

    private void OnDisable()
    {
        CrawlableObject.SendLocationEvent -= Interact;
    }
}