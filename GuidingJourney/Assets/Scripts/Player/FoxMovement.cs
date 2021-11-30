using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoxMovement : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private CharacterController charController = null;
    [SerializeField] private Camera mainCamera = null;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 40f;
    [SerializeField] private float turnSpeed = 100f;

    //Stored Values
    private Vector3 movementDirection = Vector3.zero;
    
    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    private void Update()
    {
        MoveThePlayer();
        TurnThePlayer();
    }

    private Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward = Vector3.Normalize(cameraForward);
        cameraRight = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraForward;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;
    }

    private void TurnThePlayer()
    {
        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(CameraDirection(movementDirection), Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, turnSpeed * Time.deltaTime);
        }
    }

    private void MoveThePlayer()
    {
        charController.Move(CameraDirection(movementDirection) * movementSpeed * Time.deltaTime);
    }
}