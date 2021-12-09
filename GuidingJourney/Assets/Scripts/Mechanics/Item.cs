using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private GameObject player;
    //NEED CHECKOUT
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform holdTransform;

    [Header("Range Settings")]
    [SerializeField] private float objectRange = 10f;

    private bool isHoldingItem = false;

    [Header("WIP")]
    //Needs to be managed by gameManager later in the game
    [SerializeField] private bool isInChapter = false;

    //Activated by Action event from PlayerController
    private void GrabObjects()
    {
        if(isInChapter)
        {
            //Check if distance is within reach and if it is not already holding an item
            if (!isHoldingItem && Vector3.Distance(this.transform.position, player.transform.position) < objectRange)
            {
                if (!isHoldingItem)
                {
                    //Grab item 

                    //Set item to specific parent
                    this.transform.parent = parentTransform;

                    //Set item to specific location
                    this.transform.position = holdTransform.position;
                    
                    isHoldingItem = true;
                }
            }
            else if (isHoldingItem)
            {
                //Drop item

                //Disconnect from parent
                this.transform.parent = null;

                //Set item to the ground
                this.transform.position = new Vector3(this.transform.position.x, -21.7f, this.transform.position.z);

                isHoldingItem = false;
            }
            else
            {
                return;
            }
        }
        else if(!isInChapter)
        {
            return;
        }     
    }

    //Recieves action event and connects it to methods
    private void OnEnable()
    {
        PlayerController.OnGrabEvent += GrabObjects;
    }

    //Recieves action event and disconnect it to methods

    private void OnDisable()
    {
        PlayerController.OnGrabEvent -= GrabObjects;
    }

    //Gives visible feedback for the area of the method GrabObjects
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, objectRange);
        Gizmos.color = Color.red;
    }
}