using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElinahDialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tags.NPC)
        {
            HRDTaskList.Instance.SetWeirdVoicesActive = true;
        }
    }
}