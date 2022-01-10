using UnityEngine;
using System;

public class HumanRightsDefenderNPC : MonoBehaviour
{
    public static Action<bool> GrabbedItemEvent;

    [SerializeField] private GameObject targetObject = null;
    [SerializeField] private float minRange = 200f;

    // Update is called once per frame
    private void Update()
    {
        if(Vector3.Distance(targetObject.transform.position, transform.position) < minRange)
        {
            Destroy(targetObject);
            if(GrabbedItemEvent != null)
            {
                GrabbedItemEvent(true);
            }
        }
        
    }
}