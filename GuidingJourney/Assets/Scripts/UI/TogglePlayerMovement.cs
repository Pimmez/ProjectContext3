using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Toggle toggleMovement;

    public void ToggleSmoothMovement()
    {
        playerController.IsSmoothMovement = toggleMovement.isOn;
    }
}