using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private FoxMovement foxMovement = null;
    [SerializeField] private PlayerInput playerInput = null;

    //Action Events
    public static Action OnGrabEvent;
    public static Action OnCrawlEvent;
    public static Action TestButtonEvent;


    [Header("Input Settings")]
    [SerializeField] private float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement = Vector3.zero;
    private Vector3 smoothInputMovement = Vector3.zero;
  
    //Getters & Setters
    public bool IsSmoothMovement { get { return isSmoothMovement; } set { isSmoothMovement = value; } }
    private bool isSmoothMovement = false;

    //Event to get the OnGrab Keyinput
    public void OnGrab(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            //Interaction Action/Invoke
            if(OnGrabEvent != null)
            {
                OnGrabEvent();
            }
        }
    }

    //Event to get the OnCrawl Keyinput
    public void OnCrawl(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("OnCrawl::Activated");    
            if(OnCrawlEvent != null)
            {
                OnCrawlEvent();
            }
        }
    }

    //Event to get the TestButton Keyinput
    public void TestButton(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Test button queue");
            if (TestButtonEvent != null)
            {
                TestButtonEvent();
            }
        }
    }

    //Event to get the OnMovement axis
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    //Update Loop - Used for calculating frame-based data
    private void Update()
    {
        if(isSmoothMovement)
        {
            CalculateMovementInputSmoothing();
            UpdatePlayerMovement(smoothInputMovement);
        }
        else if(!isSmoothMovement)
        {
            UpdatePlayerMovement(rawInputMovement);
        }        
    }

    //Change Input axis from raw to smoot input
    private void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    //Send data to foxMovement script
    private void UpdatePlayerMovement(Vector3 _movement)
    {
        foxMovement.UpdateMovementData(_movement);
    }

    //Gamemanager set input true or false
    public void SetInputActiveState(bool gameIsPaused)
    {
        switch (gameIsPaused)
        {
            case true:
                playerInput.DeactivateInput();
                break;

            case false:
                playerInput.ActivateInput();
                break;
        }
    }
}