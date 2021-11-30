using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    [Header("Sub Behaviours")]
    public FoxMovement foxMovement;



    public void OnGrab(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("OnGrab::Activated");
        }
    }

    public void OnCrawl(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("OnCrawl::Activated");
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Debug.Log("OnMovement::Activated");

        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    //Update Loop - Used for calculating frame-based data
    private void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
    }

    //Input's Axes values are raw
    private void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    private void UpdatePlayerMovement()
    {
        foxMovement.UpdateMovementData(smoothInputMovement);
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