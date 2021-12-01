using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 30;

    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;


    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        //_rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        //_rb.AddForce(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);

        //_rb.AddForce(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);

        //_rb.velocity = transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.fixedDeltaTime;
        _rb.velocity = transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.fixedDeltaTime;
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