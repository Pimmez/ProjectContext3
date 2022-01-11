using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WoodenBlockade : MonoBehaviour
{
    public static Action<int> ActivateTaskEvent;
    [SerializeField] private int taskNumber;

    private void Update()
    {
        if(this.gameObject == null)
        {
            Debug.Log("activeself woodenblocakde gone");
            if(ActivateTaskEvent != null)
            {
                ActivateTaskEvent(taskNumber);
            }
        }
    }
}