using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HRDRadius : MonoBehaviour
{
    public static Action OnWalkEvent;
    public static Action FinishEvent;

    public bool isWalkingTowards = false;
    public bool isEnding = false;
    public bool isUsingThis = false;


    [SerializeField] private GameObject player = null;

    private void Awake()
    {
        isEnding = false;
        isWalkingTowards = false;
    }

    private void Update()
    {
        if(isUsingThis)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) <= 20)
            {
                if (!isWalkingTowards && !isEnding)
                {
                    if (OnWalkEvent != null)
                    {
                        OnWalkEvent();
                    }
                    isWalkingTowards = true;
                }
                else if (isWalkingTowards && isEnding)
                {
                    if (FinishEvent != null)
                    {
                        FinishEvent();
                    }
                }
            }
        }
        else
        {
            return;
        }
        
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tags.PLAYER && !isWalkingTowards)
        {
            if (OnWalkEvent != null)
            {
                OnWalkEvent();
            }
            isWalkingTowards = true;
        }

        if (other.gameObject.tag == "Grab")
        {
            if (FinishEvent != null)
            {
                FinishEvent();
            }
        }
    }
    */
    private void OnDrawGizmosSelected()
    {
        // Draw a Red sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 20);
    }
}