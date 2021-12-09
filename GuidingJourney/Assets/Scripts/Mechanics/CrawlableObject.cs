using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlableObject : MonoBehaviour
{
    public static Action<bool> CanCrawl;
    public static Action<GameObject> SendLocationEvent;

    [SerializeField] private GameObject newLocation;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER && GameManager.Instance.isFoxActive.activeSelf)
        {
            isTriggered = true;
        }
        else
        {
            return;
        }

        if (CanCrawl != null)
        {
            CanCrawl(isTriggered);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(GameManager.Instance.isDoveActive.activeSelf)
        {
            isTriggered = false;
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = false;
        }

        if (CanCrawl != null)
        {
            CanCrawl(isTriggered);
        }
    }

    public void Interaction()
    {
        if(SendLocationEvent != null)
        {
            SendLocationEvent(newLocation);
        }
    }

    private void OnEnable()
    {
        PlayerController.OnCrawlEvent += Interaction;
    }

    private void OnDisable()
    {
        PlayerController.OnCrawlEvent -= Interaction;
    }
}