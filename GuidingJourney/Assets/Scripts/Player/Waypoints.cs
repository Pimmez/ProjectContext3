using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private List<Transform> routes = new List<Transform>();
    [SerializeField] private GameObject player = null;

    [Header("Settings")]
    [SerializeField] private float speed = 300f;
    [SerializeField] private float radius = 250f;

    [Header("Readable Route")]
    [SerializeField] private GameObject activeRoute = null;
    [SerializeField] private int routeCounter = 0;

    private List<Transform> childRoutes = new List<Transform>();
    private Transform targetNode;
    private int childCounter = 0;
    private int childNodes;

    [SerializeField] private bool canMove = false;

    private void Awake()
    {
        canMove = true;
        routeCounter = 0;
        childCounter = 0;
        CheckWaypointsRoute(routeCounter);
    }



    private void MoveToWaypoint()
    {
        if (transform.position == targetNode.position)
        {
            childCounter++;


            if (childCounter != childNodes)
            {
                targetNode = childRoutes[childCounter];
            }
            else if (childCounter == childNodes)
            {
                //Last waypoint in the list.

                //Reset waypoints to begin
                //currentWaypoint = 0;

                //Make bool to let HRD wait
                //After bool/task complete go to next route section with new waypoints.
                canMove = false;
                //Check if bool, int already is completed if so move on otherwise wait here


                routeCounter++;

                if (routeCounter < routes.Count)
                {

                    childRoutes.Clear();
                    childCounter = -1;

                    CheckWaypointsRoute(routeCounter);
                }
                else
                {
                    //go back to begin route
                    //routeToGo = 0;
                    return;
                }
            }
        }
    }

    //Update code loop
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius && childCounter < childNodes)
        {
            if (targetNode == null)
            {
                targetNode = childRoutes[childCounter];
            }


            MoveToWaypoint();

            if (canMove)
            {
                WalkAround();
            }
        }
    }

    //Let the HRD walk || NEED TO GO TO OWN HRD CLASS
    private void WalkAround()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetNode.position - transform.position, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, targetNode.position, speed * Time.deltaTime);
    }

    //Set new routes and childRoutes
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

        //Set routes to activeRoute so I can check what route is active in the inspector
        activeRoute = routes[routeNumber].gameObject;
    }

    //Show the walkable area in the HRD
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void SetMovement(bool _boolean)
    {
        canMove = _boolean;
    }

    private void OnEnable()
    {
        HRDTaskList.GrabbedItemEvent += SetMovement;
        HRDTaskList.Task3AEvent += SetMovement;
        HRDTaskList.Task3BEvent += SetMovement;
        HRDTaskList.Task3CEvent += SetMovement;
        HRDTaskList.CampSiteEvent += SetMovement;
    }

    private void OnDisable()
    {
        HRDTaskList.GrabbedItemEvent -= SetMovement;
        HRDTaskList.Task3AEvent -= SetMovement;
        HRDTaskList.Task3BEvent -= SetMovement;
        HRDTaskList.Task3CEvent -= SetMovement;
        HRDTaskList.CampSiteEvent -= SetMovement;
    }
}