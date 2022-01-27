using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LetterInteraction : MonoBehaviour
{
    public static Action<bool> DoveGrabEvent;
    private bool isTriggered = false;
    [SerializeField] private Transform doveHoldTransform;
    [SerializeField] private Collider col;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private float itemDropHeight = 25f;

    private bool doveHoldingLetter = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tags.DOVE)
        {
            isTriggered = true;
            Debug.Log("TriggerTrue Letter");
        }

        if (DoveGrabEvent != null)
        {
            DoveGrabEvent(isTriggered);
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.tag == Tags.DOVE)
        {
            isTriggered = false;
        }

        if (DoveGrabEvent != null)
        {
            DoveGrabEvent(isTriggered);
        }
    }

    private void Update()
    {
        if(doveHoldingLetter)
        {
            this.transform.position = doveHoldTransform.position;
        }
    }

    private void GrabLetter()
    {
        Debug.Log("Grab Letter Activation");

        if (GameManager.Instance.isDoveActive.activeSelf && !GameManager.Instance.isHoldingObject)
        {
            Debug.Log("Grab Letter Activation + incode");

            GameManager.Instance.isHoldingObject = true;
            //anim.SetTrigger("isGrabbing");
            this.transform.parent = parentTransform;
            doveHoldingLetter = true;
            col.enabled = false;
            //Grab item 
            //GameManager.Instance.isHoldingObject = true;
            //Set item to specific parent


            //Set item to specific location
        }
        else if (GameManager.Instance.isHoldingObject)
        {
            Debug.Log("drop letter + incode");

            //Drop item
            doveHoldingLetter = false;
            //Disconnect from parent
            this.transform.parent = null;

            //Set item to the ground
            this.transform.position = new Vector3(this.transform.position.x, itemDropHeight, this.transform.position.z);

            GameManager.Instance.isHoldingObject = false;
            //isHoldingItem = false;

            col.enabled = true;

            //anim.SetTrigger("isIdle");
        }
    }

    private void OnEnable()
    {
        PlayerController.OnDoveGrabEvent += GrabLetter;
    }

    //Recieves action event and disconnect it to methods
    private void OnDisable()
    {
        PlayerController.OnDoveGrabEvent -= GrabLetter;
    }
}