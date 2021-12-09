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
    private GameObject newLocation;

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
        this.transform.position = new Vector3(newLocation.transform.position.x, -21.7f, newLocation.transform.position.z);
        GameManager.Instance.isGamePaused = false;

        anim.SetTrigger("isIdle");

        characterController.enabled = true;
        if (EndFadeEvent != null)
        {
            EndFadeEvent();
        }
    }

    private void Interact(GameObject _location)
    {
        Debug.Log("PlayerInteractions::Action");
        Debug.Log("Other location: " + _location);
        newLocation = _location;

        Debug.Log("PlayerInteractions::OnCrawlBegin");
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