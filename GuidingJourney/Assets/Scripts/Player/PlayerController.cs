using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private FoxMovement foxMovement = null;
    [SerializeField] private PlayerInput playerInput = null;

    [Header("Input Settings")]
    [SerializeField] private float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement = Vector3.zero;
    private Vector3 smoothInputMovement = Vector3.zero;

    //Event to get the OnGrab Keyinput
    public void OnGrab(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("OnGrab::Activated");
        }
    }

    //Event to get the OnCrawl Keyinput
    public void OnCrawl(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("OnCrawl::Activated");
        }
    }

    //Event to get the OnMovement axis
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

    //Change Input axis from raw to smoot input
    private void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    //Send data to foxMovement script
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