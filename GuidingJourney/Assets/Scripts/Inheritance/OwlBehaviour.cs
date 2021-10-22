using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBehaviour : AnimalBehaviour
{
    private CharacterController charController;

    private float speed = 10f;
    private float climbSpeed = 20f;
    private float turnspeed = 30f;
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = 9.8f;
    private float groundCheckSphere = 0.01f;

    private Vector3 playerVelocity;


    [SerializeField] private bool isFlying = false;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private float ground = 0.1f;

    

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckSphere, groundMask);

            //my movement
            if (isGrounded)
            {
                Debug.Log("grounded movement");
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                charController.Move(moveDirection * Time.deltaTime * speed);
            }

            //liftoff
            if(isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("liftoff");
                moveDirection.y += Mathf.Sqrt(climbSpeed * -3.0f * gravity);
            }

            moveDirection.y += gravity * Time.deltaTime;
            charController.Move(moveDirection * Time.deltaTime);

            if (isFlying)
            {
                //
            }

            /*
            isFlying = false;
            
            //rotation
            if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            {
                //Quaternion _target = Quaternion.Euler(transform.rotation.x, Mathf.Clamp)
            }

            //move
            if(Input.GetKeyDown(KeyCode.W))
            {
                if(transform.position.y > ground)
                {
                    moveDirection = new Vector3(moveDirection.x * speed, moveDirection.y, moveDirection.z * speed);
                    isFlying = true;
                }
            }

            //fly
            if(Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = climbSpeed;
                isFlying = true;
            }

            //apply if gameover not true
            if(moveDirection != Vector3.zero)
            {
                charController.Move(moveDirection * Time.deltaTime);
                if(transform.position != transform.position + moveDirection * Time.deltaTime)
                {
                    transform.position = transform.position + moveDirection * Time.deltaTime;
                }
            }

            //gravity
            if(transform.position.y > ground) //!isGrounded
            {
                moveDirection.y = moveDirection.y + (Physics.gravity.y * gravity) * Time.deltaTime;
            }
            else
            {
                moveDirection.y = moveDirection.y * Time.deltaTime;
            }
            */
    }

    private void NightVision()
    {
        //
    }

    protected override void AnimalBaseMovement()
    {
        base.AnimalBaseMovement();
    }
    protected override void CameraBaseMovement()
    {
        base.CameraBaseMovement();
    }

    protected override void SpecialBasePower()
    {
        base.SpecialBasePower();
    }
}