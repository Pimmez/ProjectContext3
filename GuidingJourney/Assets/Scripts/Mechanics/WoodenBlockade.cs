using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBlockade : MonoBehaviour
{
    [SerializeField] private int thisBlockadeNumber;
    private void RemovedKeyComponent(int _blockadeNumber)
    {
        if(_blockadeNumber == thisBlockadeNumber)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        GrabStick.GrabbedStickEvent += RemovedKeyComponent;
    }

    private void OnDisable()
    {
        GrabStick.GrabbedStickEvent -= RemovedKeyComponent;
    }
}