using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickObject : MonoBehaviour
{
    public static Action isNearObjectEvent;

    [SerializeField] private Camera cam;
    [SerializeField] private Transform playerGrabFox;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private GameObject textRemove;
    [SerializeField] private Collider col;
    [SerializeField] private HRDRadius hrdRadius;

    private bool isGrabbed = false;
    

    private void Update()
    {
        if (Vector3.Distance(parentTransform.transform.position, this.transform.position) <= 20 && !isGrabbed)
        {
            //Debug.Log("Test distance 01");
            if (isNearObjectEvent != null)
            {
                //Debug.Log("Test message 01");

                isNearObjectEvent();
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;


            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Grab")
            {
                //Debug.Log("You selected the " + hit.transform.name); 
                //Debug.Log("Position of the clicked object: " + hit.transform.position);

                if(Vector3.Distance(parentTransform.transform.position, this.transform.position) <= 15 && !isGrabbed)
                {

                    //Debug.Log("GRAB");
                  
                    textRemove.SetActive(false);

                    transform.position = playerGrabFox.position;
                    transform.SetParent(parentTransform);
                    col.enabled = false;
                    isGrabbed = true;
                    hrdRadius.isEnding = true;
                }
                
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 20);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 15);
    }
}