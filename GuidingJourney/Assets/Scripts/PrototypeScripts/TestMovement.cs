using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Rigidbody rigid;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Camera mainCamera;

    private Vector3 forward, right, movement;
    private bool moving = false;

    private void Awake()
    {
        forward = mainCamera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        //Cheesy way to stop the sliding
        if (movement == Vector3.zero)
        {
            //Debug.Log("Keys are lose");
            rigid.isKinematic = true;
        }
        else
        {
            rigid.isKinematic = false;
        }

    }

    private void FixedUpdate()
    {
        Vector3 rightMovement = right * moveSpeed * Time.fixedDeltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;

        rigid.AddForce((rightMovement + upMovement) * moveSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}