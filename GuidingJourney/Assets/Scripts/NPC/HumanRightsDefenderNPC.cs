using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRightsDefenderNPC : MonoBehaviour
{
    [SerializeField] private Transform targetObject = null;

    [SerializeField] private float minRange = 6f;

    private int movementSpeed = 0;
    public int mSpeed = 4;

    private int turnSpeed = 0;
    public int tSpeed = 3;


    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(Vector3.Distance(targetObject.position, transform.position) > minRange)
        {
            InitializeMovement();

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetObject.position - transform.position), turnSpeed * Time.deltaTime);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else
        {
            DisableMovement();
            return;
        }
    }

    private void InitializeMovement()
    {
        movementSpeed = mSpeed;
        turnSpeed = tSpeed;
    }

    private void DisableMovement()
    {
        movementSpeed = 0;
        turnSpeed = 0;
    }
}