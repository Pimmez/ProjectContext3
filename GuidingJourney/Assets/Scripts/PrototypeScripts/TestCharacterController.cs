using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public float moveSpeed;
    [SerializeField] private CharacterController charController;

    public Vector3 movement;
    public Vector3 forward;
    public Vector3 right;
    public float time = 0.1f;


    private bool moving = false;

    private void Awake()
    {
        forward = mainCamera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        // Save the state of the horizontal and vertical input axis (-1, 0, or 1)
        float forwardAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        // Calculate the direction vector that we want to move towards then move.
        Vector3 direction = Vector3.Normalize(right * horizontalAxis + forward * forwardAxis);

        // Turn the player towards the direction they are moving towards
        transform.forward = Vector3.Lerp(transform.forward, direction, time);

        charController.Move(direction * moveSpeed * Time.deltaTime);
    }
}
