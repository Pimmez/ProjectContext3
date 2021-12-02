using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlMechanicTest : MonoBehaviour
{
    [SerializeField] private Transform otherPos = null;
    [SerializeField] private Transform parentTransform = null;
    [SerializeField] private CharacterController charController = null;
    private bool isAtB = false;

    private void OnTriggerEnter(Collider other)
  {
      if(other.gameObject.tag == Tags.PLAYER && !isAtB)
      {
          charController.enabled = false;
          parentTransform.position = otherPos.position;
          isAtB = true;
          charController.enabled = true;

      }
      else if(other.gameObject.tag == Tags.PLAYER && isAtB)
      {
          charController.enabled = false;
          parentTransform.position = otherPos.position;
          isAtB = false;
          charController.enabled = true;

      }
  }


    private void OnDrawGizmosSelected()
    {
        // Draw a Red sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}