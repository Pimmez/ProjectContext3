using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{

    private void Test()
    {
        //
    }

    protected virtual bool CheckActiveState(bool _isActive)
    {
        if(gameObject.activeSelf)
        {
            _isActive = true;
        }
        else if(!gameObject.activeSelf)
        {
            _isActive = false;
        }
        return _isActive;
    }

    protected virtual void AnimalMovement()
    {
        //
    }

    protected virtual void SpecialPower()
    {
        //
    }
}