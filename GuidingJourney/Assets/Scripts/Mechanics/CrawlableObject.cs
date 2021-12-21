using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlableObject : MonoBehaviour
{
    public static Action<bool, int> CanCrawl;
    public static Action<Transform> SendLocationEvent;

    public int crawlObject;
    public int caveNumber;

    [SerializeField] private Transform otherLocation = null;
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
            CanCrawl(isTriggered, crawlObject);
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
            CanCrawl(isTriggered, crawlObject);
        }
    }

    public void Interaction(int _caveType)
    {
        otherLocation = this.gameObject.transform.GetChild(0);

        if(SendLocationEvent != null && caveNumber == _caveType)
        {
            Debug.Log("2x?");
            Debug.Log("otherLocation: " + otherLocation);
            SendLocationEvent(otherLocation);
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