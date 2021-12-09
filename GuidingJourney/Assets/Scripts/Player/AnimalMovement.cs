using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private CharacterController charController = null;
    [SerializeField] private Camera mainCamera = null;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 40f;
    [SerializeField] private float turnSpeed = 100f;

    //Stored Values
    private Vector3 movementDirection = Vector3.zero;
    
    //Get NewMovementeDirection Data in from PlayerController and set it to movementDirection
    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    private void Update()
    {
        MoveThePlayer();
        TurnThePlayer();
    }

    //Set the camera direction to isometric view
    private Vector3 CameraDirection(Vector3 movementDirection)
    {
        //Set forward to equal the camera's forward vector
        Vector3 cameraForward = mainCamera.transform.forward; 
        
        //Set forward to equal the camera's right vector
        Vector3 cameraRight = mainCamera.transform.right; 

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        //make sure the length of vector is set to a max of 1.0
        cameraForward = Vector3.Normalize(cameraForward);
        
        //set the right-facing vector to be facing right relative to the camera's forward vector
        cameraRight = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraForward; 

        //set the calculation in a parameter
        Vector3 calculateDirection = cameraForward * movementDirection.z + cameraRight * movementDirection.x;
        
        //return calculation
        return calculateDirection; 
    }

    //Rotate the object
    private void TurnThePlayer()
    {
        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(CameraDirection(movementDirection), Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, turnSpeed * Time.deltaTime);
        }
    }

    //Move the object
    private void MoveThePlayer()
    {
        charController.Move(CameraDirection(movementDirection) * movementSpeed * Time.deltaTime);
    }
}