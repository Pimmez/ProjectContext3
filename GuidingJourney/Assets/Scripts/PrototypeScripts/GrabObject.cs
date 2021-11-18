using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private Transform playerGrabFox;
    [SerializeField] private Transform parentTransform;
    [SerializeField] GameObject textRemove;
    [SerializeField] private HRDRadius hrdRadius;

    private bool isGrabbed = false;
    bool triggered = false;


    private void Update()
    {
        if (triggered && !isGrabbed && Input.GetKeyDown(KeyCode.Space))
        {
            //Do something!
            //Debug.Log("GRAB");
            textRemove.SetActive(false);

            transform.position = playerGrabFox.position;

            transform.SetParent(parentTransform);
            isGrabbed = true;
            hrdRadius.isEnding = true;
        }
        else if (triggered && Input.GetKeyDown(KeyCode.Space) && isGrabbed)
        {
            //Debug.Log("LET GO");
            transform.SetParent(null);

            transform.position = new Vector3(playerGrabFox.position.x, -3.15f, playerGrabFox.position.z);

            isGrabbed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered");
        if (other.gameObject.tag == Tags.PLAYER)
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exited");
        if (other.gameObject.tag == Tags.PLAYER)
        {
            triggered = false;
        }
    }
}