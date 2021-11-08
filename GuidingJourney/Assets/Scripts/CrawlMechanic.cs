using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlMechanic : MonoBehaviour
{
    [SerializeField] private Transform positionA, positionB;
    [SerializeField] private Transform parentTransform;
    private bool isAtB = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tags.PLAYER && !isAtB)
        {
            parentTransform.position = positionB.position;
            isAtB = true;
        }
        else if(other.gameObject.tag == Tags.PLAYER && isAtB)
        {
            parentTransform.position = positionA.position;
            isAtB = false;
        }
    }
}