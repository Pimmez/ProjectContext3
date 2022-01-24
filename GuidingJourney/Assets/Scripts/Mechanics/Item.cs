using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform foxHoldTransform;
    [SerializeField] private Transform doveHoldTransform;
    [SerializeField] private GameObject image;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider col;

    [Header("Item Values")]
    [SerializeField] private float itemDropHeight = 25f;

    //Action Events
    public static Action<bool> CanGrabEvent;

    //Privates
    private bool isTriggered = false;
    private bool isDoingOnceImage = false;


    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == Tags.PLAYER)
        {
            isTriggered = true;
            if (!isDoingOnceImage)
            {
                image.SetActive(true);
                isDoingOnceImage = true;
            }
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
            image.SetActive(false);
        }

        if (CanGrabEvent != null)
        {
            CanGrabEvent(isTriggered);
        }
    }

    public void EndAnimationEvent()
    {
        anim.SetBool("isgrabbing", false);
    }

    public void AnimationEvent()
    {
        //isHoldingItem = true;
        this.transform.position = foxHoldTransform.position;
    }

    //Activated by Action event from PlayerController
    private void GrabObjects()
    {
        if (GameManager.Instance.isFoxActive.activeSelf && !GameManager.Instance.isHoldingObject)
        {
            image.SetActive(false);
            GameManager.Instance.isHoldingObject = true;
            //anim.SetTrigger("isGrabbing");
            anim.SetBool("isgrabbing", true);
            this.transform.parent = parentTransform;


            col.enabled = false;
            //Grab item 
            //GameManager.Instance.isHoldingObject = true;
            //Set item to specific parent


            //Set item to specific location
        }
        else if (GameManager.Instance.isDoveActive.activeSelf && !GameManager.Instance.isHoldingObject)
        {
            image.SetActive(false);

            //Grab item 
            GameManager.Instance.isHoldingObject = true;
            col.enabled = false;

            //Set item to specific parent
            this.transform.parent = parentTransform;

            //Set item to specific location
            this.transform.position = doveHoldTransform.position;

            //isHoldingItem = true;
        }
        else if (GameManager.Instance.isHoldingObject)
        {
            image.SetActive(false);

            //Drop item

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