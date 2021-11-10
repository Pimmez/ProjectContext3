using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private Transform playerGrabFox, playerGrabOwl;
    [SerializeField] private Transform parentTransform;

    public GameObject fox;
    public GameObject owl;

    private bool isGrabbed = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER && Input.GetKeyDown(KeyCode.Space) && !isGrabbed)
        {
            Debug.Log("GRAB");

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
        else if (other.gameObject.tag == Tags.PLAYER && Input.GetKeyDown(KeyCode.Space) && isGrabbed)
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
}