using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private Transform playerGrabFox, playerGrabOwl;
    [SerializeField] private Transform parentTransform;
    [SerializeField] GameObject textRemove;

    public GameObject fox;
    public GameObject owl;

    private bool isGrabbed = false;
    bool triggered = false;


    private void Update()
    {
        if (triggered && !isGrabbed && Input.GetKeyDown(KeyCode.Space))
        {
            //Do something!
            Debug.Log("GRAB");
            textRemove.SetActive(false);
            if (fox.activeSelf)
            {
                transform.position = playerGrabFox.position;
            }
            else if (owl.activeSelf)
            {
                transform.position = playerGrabOwl.position;
            }
            transform.SetParent(parentTransform);
            isGrabbed = true;
        }
        else if (triggered && Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {

            Debug.Log("LET GO");
            transform.SetParent(null);
            if (fox.activeSelf)
            {
                transform.position = new Vector3(playerGrabFox.position.x, -3.15f, playerGrabFox.position.z);
            }
            else if (owl.activeSelf)
            {
                transform.position = new Vector3(playerGrabOwl.position.x, -3.15f, playerGrabOwl.position.z);
            }
            isGrabbed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.gameObject.tag == Tags.PLAYER)
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        if (other.gameObject.tag == Tags.PLAYER)
        {
            triggered = false;
        }
    }
}