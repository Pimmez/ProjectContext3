using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrabStick : MonoBehaviour
{
    public static Action<int> GrabbedStickEvent;
    public static Action<bool, int> CanGrabStickEvent;
    [SerializeField] private int blockadeNumber;
    public int blockadeType;
    [SerializeField] private AudioClip sfxClip = null;

    private bool isTriggered = false;
    [SerializeField] private GameObject blockade;
    private bool isDoingOnceImage = false;

    [SerializeField] private GameObject image;

    public static Action<int> ActivateTaskEvent;
    [SerializeField] private int taskNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = true;
            if (!isDoingOnceImage)
            {
                image.SetActive(true);
                isDoingOnceImage = true;
            }
        }

        if (CanGrabStickEvent != null)
        {
            CanGrabStickEvent(isTriggered, blockadeNumber);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = false;
            image.SetActive(false);

        }

        if (CanGrabStickEvent != null)
        {
            CanGrabStickEvent(isTriggered, blockadeNumber);
        }
    }

    private void RemoveStick(int _blockadeType)
    {
        if (blockadeType == _blockadeType)
        {
            //Debug.Log("activeself woodenblocakde gone");
            if (ActivateTaskEvent != null)
            {
                ActivateTaskEvent(taskNumber);
            }
            Destroy(this.gameObject);
            Destroy(blockade);
            image.SetActive(false);
            SoundManager.Instance.Play(sfxClip);

        }
    }

    private void OnEnable()
    {
        PlayerController.OnStickGrabEvent += RemoveStick;
    }

    private void OnDisable()
    {
        PlayerController.OnStickGrabEvent -= RemoveStick;
    }
}