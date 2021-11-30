using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoxMovement : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private CharacterController charController;
    [SerializeField] private Camera mainCamera;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float turnSpeed = 0.1f;

    [Header("Turn Settings")]
    [SerializeField] private float time = 0.1f;
    
    //Stored Values
    private Vector3 movementDirection;
    private Vector3 forward;
    private Vector3 right;


    private void Awake()
    {
        forward = mainCamera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    private void Update()
    {
        MoveThePlayer();
        CameraDirection();
    }

    private void MoveThePlayer()
    {
        //Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
        charController.Move(movementDirection * movementSpeed * Time.deltaTime);    
    }

    private void CameraDirection()
    {
        Vector3 direction = Vector3.Normalize(right * movementDirection.z + forward * movementDirection.x);
        /*
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;
        */
       
        /*
        // Turn the player towards the direction they are moving towards
        if(movementSpeed != 0)
        {
            transform.forward = Vector3.Lerp(transform.forward, direction, time);
        }
        */
    }
}