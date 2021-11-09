using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickMovement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent playerNav;
    public GameObject targetDestination;

    public GameObject fox;

    private void Start()
    {
       // playerNav.height = -3.5f;
        //playerNav.baseOffset = -3.5f;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray _ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hitPoint;
        
            if(Physics.Raycast(_ray, out _hitPoint))
            {
                targetDestination.transform.position = _hitPoint.point;
                playerNav.SetDestination(_hitPoint.point);
            }
        }

        if(playerNav.velocity != Vector3.zero)
        {
            //
        }

        if(fox.activeSelf)
        {
            playerNav.speed = 10;
        }
        else
        {
            playerNav.speed = 6;
        }
    }

}