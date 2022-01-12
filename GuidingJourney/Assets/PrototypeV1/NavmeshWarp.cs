using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshWarp : MonoBehaviour
{
    [SerializeField] private Transform positionA, positionB;
    [SerializeField] private NavMeshAgent nav;
    private bool isAtB = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLAYER && !isAtB)
        {
            nav.Warp(positionB.position);
            isAtB = true;
        }
        else if (other.gameObject.tag == Tags.PLAYER && isAtB)
        {
            nav.Warp(positionA.position);
            isAtB = false;
        }
    }
}
