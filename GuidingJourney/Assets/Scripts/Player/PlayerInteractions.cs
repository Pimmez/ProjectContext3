using System;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] CharacterController characterController;
    [SerializeField] private Animator anim;
    
    //Action Events
    public static Action StartFadeEvent;
    public static Action EndFadeEvent;

    //Privates
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

        anim.SetBool("iscrawling", false);

        //anim.SetTrigger("isIdle");

        characterController.enabled = true;
        if (EndFadeEvent != null)
        {
            EndFadeEvent();
            //crawlToLocation = null;
        }
    }

    public void EndCrawlingAnimation()
    {
        anim.SetBool("iscrawling", false);
        Debug.Log(anim.GetBool("iscrawling"));
    }

    private void Interact(Transform _location)
    {
        Debug.Log("Interaction to interaction time to start crawl animation");

        characterController.enabled = false;
        crawlToLocation = _location;

        GameManager.Instance.isGamePaused = true;

        //Do Fox Crawl Animation
        //anim.SetTrigger("isCrawling");

        anim.SetBool("iscrawling", true);
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