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

    private bool isTriggered = false;
    [SerializeField] private GameObject blockade;


    public static Action<int> ActivateTaskEvent;
    [SerializeField] private int taskNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = true;
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
            Debug.Log("activeself woodenblocakde gone");
            if (ActivateTaskEvent != null)
            {
                ActivateTaskEvent(taskNumber);
            }
            Destroy(this.gameObject);
            Destroy(blockade);
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