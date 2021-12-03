using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlableObject : MonoBehaviour, IInteractable
{
    public static Action<bool> CanCrawl;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
            isTriggered = true;
        if (CanCrawl != null)
        {
            CanCrawl(isTriggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
            isTriggered = false;
        if (CanCrawl != null)
        {
            CanCrawl(isTriggered);
        }
    }

    public void Interact()
    {

    }
}