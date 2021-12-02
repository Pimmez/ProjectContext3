using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlMechanic : MonoBehaviour
{
    public static Action StartFadeEvent;
    public static Action EndFadeEvent;


    private float rangeToCrawl = 5f;
    private Transform _otherPosition;

    private void OnCrawl()
    {
        if(Vector3.Distance(this.transform.position, _otherPosition.position) < rangeToCrawl)
        {
            //Do Fox Crawl Animation

            //Start Fade Normally done in the animation with a keyframe function
            if(StartFadeEvent != null)
            {
                StartFadeEvent();
            }

            //Teleport Fox

            //End Fade
            if(EndFadeEvent != null)
            {
                EndFadeEvent();
            }
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