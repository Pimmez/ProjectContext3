using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform foxHoldTransform;
    [SerializeField] private Transform doveHoldTransform;
    
    [Header("Item Values")]
    [SerializeField] private float itemDropHeight = 25f;

    //Action Events
    public static Action<bool> CanGrabEvent;

    //Privates
    private bool isHoldingItem = false;
    private bool isTriggered = false;


    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = true;
        }

        if (CanGrabEvent != null)
        {
            CanGrabEvent(isTriggered);
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = false;
        }

        if (CanGrabEvent != null)
        {
            CanGrabEvent(isTriggered);
        }
    }

    //Activated by Action event from PlayerController
    private void GrabObjects()
    {
        if (GameManager.Instance.isFoxActive.activeSelf && !isHoldingItem)
        {
            //Grab item 
            GameManager.Instance.isHoldingObject = true;
            //Set item to specific parent
            this.transform.parent = parentTransform;

            //Set item to specific location
            this.transform.position = foxHoldTransform.position;

            isHoldingItem = true;
        }
        else if (GameManager.Instance.isDoveActive.activeSelf && !isHoldingItem)
        {
            //Grab item 
            GameManager.Instance.isHoldingObject = true;

            //Set item to specific parent
            this.transform.parent = parentTransform;

            //Set item to specific location
            this.transform.position = doveHoldTransform.position;

            isHoldingItem = true;
        }
        else if (isHoldingItem)
        {
            //Drop item
            GameManager.Instance.isHoldingObject = false;

            //Disconnect from parent
            this.transform.parent = null;

            //Set item to the ground
            this.transform.position = new Vector3(this.transform.position.x, itemDropHeight, this.transform.position.z);

            isHoldingItem = false;
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
}