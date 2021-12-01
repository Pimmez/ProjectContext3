using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float objectRange = 10f;

    private bool isHoldingItem = false;


    //NEED
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform holdTransform;


    //Needs to be managed by gameManager later in the game
    [SerializeField] private bool isInChapter = false;

    private void GrabObjects()
    {
        if(isInChapter)
        {
            if (!isHoldingItem && Vector3.Distance(this.transform.position, player.transform.position) < objectRange)
            {
                Debug.Log("Can Grab Item");
                if (!isHoldingItem)
                {
                    //Grab item 
                    this.transform.parent = parentTransform;
                    this.transform.position = holdTransform.position;
                    isHoldingItem = true;
                }
            }
            else if (isHoldingItem)
            {
                this.transform.parent = null;
                this.transform.position = new Vector3(this.transform.position.x, -3.0f, this.transform.position.z);
                //put item on the ground
                isHoldingItem = false;
            }
            else
            {
                Debug.Log("Item to far away :(");
                return;
            }
        }
        else if(!isInChapter)
        {
            return;
        }     
    }

    private void OnEnable()
    {
        PlayerController.OnGrabEvent += GrabObjects;
    }

    private void OnDisable()
    {
        PlayerController.OnGrabEvent -= GrabObjects;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, objectRange);
        Gizmos.color = Color.blue;
    }

}