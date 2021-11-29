using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressToGrab : MonoBehaviour
{
    public static Action isNearObjectEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER)
        {
            if (isNearObjectEvent != null)
            {
                isNearObjectEvent();
            }
        }
    }
}