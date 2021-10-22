using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    // Getter and setter
    public float animalWalkMovement { get { return movementSpeed; } set { movementSpeed = value; } }
    private float movementSpeed;
    public float animalTurningMovement { get { return rotationSpeed; } set { rotationSpeed = value; } }
    private float rotationSpeed = 30f;
    private float universalGravity { get { return gravity; } }
    private float gravity = 9.8f;

    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;  

    private void Start()
    {

    }
    private void Update()
    {
        
    }

    

    protected virtual void AnimalBaseMovement()
    {
        //
    }

    protected virtual void CameraBaseMovement()
    {
        //
    }

    protected virtual void SpecialBasePower()
    {
        //
    }
}