using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private Transform playerGrabPos;
    [SerializeField] private Transform parentTransform;

    private bool isGrabbed = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER && Input.GetKeyDown(KeyCode.Space) && !isGrabbed)
        {
            Debug.Log("GRAB");
            transform.position = playerGrabPos.position;
            transform.SetParent(parentTransform);
            isGrabbed = true;
        }
        else if (other.gameObject.tag == Tags.PLAYER && Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {
            Debug.Log("LET GO");
            transform.SetParent(null);
            transform.position = new Vector3(playerGrabPos.position.x, -3.15f, playerGrabPos.position.z);
            isGrabbed = false;
        }
    }
}