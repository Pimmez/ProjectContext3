using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private List<Transform> routes = new List<Transform>();
    [SerializeField] private GameObject player;

    [Header("Settings")]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float radius;

    [Header("Readable Route")]
    [SerializeField] private GameObject activeRoute;

    private List<Transform> childRoutes = new List<Transform>();
    private Transform targetNode;
    private int routeCounter = 0;
    private int childCounter = 0;
    private int childNodes;



    private void Awake()
    {
        routeCounter = 0;
        childCounter = 0;
        CheckWaypointsRoute(routeCounter);
    }

    private void CheckWaypointsRoute(int routeNumber)
    {
        //Check the amount of childNodes in routes[]
        childNodes = routes[routeNumber].childCount;

        //for i < childCounts, add the childnodes to the childTransform[]
        for (int i = 0; i < childNodes; i++)
        {
            //childCounts = routes[routeNumber].childCount;
            childRoutes.Add(routes[routeNumber].GetChild(i).transform);
        }
        activeRoute = routes[routeNumber].gameObject;
    }

    private void MoveToWaypoint()
    {
        if (transform.position == targetNode.position)
        {
            Debug.Log("childCounter begin: " + childCounter);


            childCounter++;

            if (childCounter != childNodes)
            {
                targetNode = childRoutes[childCounter];
            }
            else if (childCounter == childNodes)
            {
                Debug.Log("Reached the last childnote");
                //Last waypoint in the list.

                //Reset waypoints to begin
                //currentWaypoint = 0;

                //Make bool to let HRD wait
                //After bool/task complete go to next route section with new waypoints.

                routeCounter++;
                childCounter = 0;
                
                Debug.Log("childCounter middle: " + childCounter);
                
                if (routeCounter > routes.Count)
                {
                    Debug.Log("MoveToWaypoint::HELLO?? No routes?");
                    //go back to begin route
                    //routeToGo = 0;
                    return;
                }
                else
                {
                    Debug.Log("Switch to next route: " + routeCounter);
                    CheckWaypointsRoute(routeCounter);
                }

                //return;
                Debug.Log("childCounter after: " + childCounter);
            }
        }
    }

    private void Update()
    {
        if (childCounter < childRoutes.Count && Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if (targetNode == null)
            {
                targetNode = childRoutes[childCounter];
            }
            WalkAround();
            MoveToWaypoint();
        }
    }

    private void WalkAround()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetNode.position - transform.position, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, targetNode.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}