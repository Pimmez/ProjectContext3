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
    private Collider newCollider;
    public IInteractable interactable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = true;
            newCollider = other;
        }

        if (CanCrawl != null)
        {
            CanCrawl(isTriggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = false;
            newCollider = null;
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

        /*
        interactable = newCollider.GetComponent<IInteractable>();
        interactable.Interact(newLocation);
        newCollider = null;
        */
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