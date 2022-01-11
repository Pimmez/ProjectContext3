using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrabStick : MonoBehaviour
{
    public static Action<int> GrabbedStickEvent;
    public static Action<bool, int> CanGrabStickEvent;
    [SerializeField] private int blockadeNumber;
    private bool isTriggered = false;

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
        Destroy(this.gameObject);
        if (GrabbedStickEvent != null && blockadeNumber == _blockadeType)
        {
            GrabbedStickEvent(blockadeNumber);
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