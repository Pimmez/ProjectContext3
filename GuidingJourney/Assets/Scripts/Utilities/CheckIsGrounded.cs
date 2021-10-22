using UnityEngine;
using System;

[Serializable]
public class CheckIsGrounded
{
    public bool CheckisGrounded(bool _isGrounded, Vector3 _position, float _radius, LayerMask _groundLayer)
    {
        _isGrounded = Physics.CheckSphere(_position, _radius, _groundLayer);
        return _isGrounded;
    }
}