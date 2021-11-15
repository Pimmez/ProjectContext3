using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HRDRadius : MonoBehaviour
{
    public static Action OnWalkEvent;
    public static Action FinishEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tags.PLAYER)
        {

            if (OnWalkEvent != null)
            {
                OnWalkEvent();
            }
        }

        if(other.gameObject.tag == "Finish")
        {
            if (FinishEvent != null)
            {
                FinishEvent();
            }
        }
    }

    
}