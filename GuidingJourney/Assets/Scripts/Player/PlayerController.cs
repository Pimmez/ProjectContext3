using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed = 15;

    Vector3 forward, right, direction;

    Vector3 _relativePos;

    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightmovement = (right * movespeed * Time.deltaTime) * Input.GetAxis("Horizontal");
        Vector3 upmovement = (forward * movespeed * Time.deltaTime) * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightmovement + upmovement);

        transform.forward = heading;
        transform.position += rightmovement;
        transform.position += upmovement;
    }
}