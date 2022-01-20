using UnityEngine;
using UnityEngine.UI;

public class TogglePlayerMovement : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Toggle toggleMovement;

    public void ToggleSmoothMovement()
    {
        playerController.IsSmoothMovement = toggleMovement.isOn;
    }
}