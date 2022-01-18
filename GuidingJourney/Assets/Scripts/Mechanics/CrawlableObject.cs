using System;
using UnityEngine;

public class CrawlableObject : MonoBehaviour
{

    [Header("Crawlobject & Cavenumber values")]
    [SerializeField] private int crawlObject;
    [SerializeField] private int caveNumber;

    [Header("Component References")]
    [SerializeField] private GameObject image;


    //Action Events
    public static Action<bool, int> CanCrawl;
    public static Action<Transform> SendLocationEvent;

    //Privates
    private Transform otherLocation = null;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == Tags.PLAYER && GameManager.Instance.isFoxActive.activeSelf)
        {
            isTriggered = true;
            image.SetActive(true);
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

    private void OnTriggerStay(Collider _other)
    {
        if (GameManager.Instance.isDoveActive.activeSelf)
        {
            isTriggered = false;
            return;
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = false;
            image.SetActive(false);
        }

        if (CanCrawl != null)
        {
            CanCrawl(isTriggered, crawlObject);
        }
    }

    public void Interaction(int _caveType)
    {
        image.SetActive(false);

        otherLocation = this.gameObject.transform.GetChild(0);

        if (SendLocationEvent != null && caveNumber == _caveType)
        {
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