using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    public List<Transform> eventWayPoints = new List<Transform>();
    public int currentWaypoint = 0;

    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float radius;

    private Transform targetWaypoint;

    private void Update()
    {
        if (currentWaypoint < points.Count && Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if (targetWaypoint == null)
            {
                targetWaypoint = points[currentWaypoint];
            }
            WalkAround();
        }
    }

    private void WalkAround()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetWaypoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (transform.position == targetWaypoint.position)
        {
            currentWaypoint++;

            /*
            if(Vector3.Distance(transform.position, eventWayPoints[0].position) < radius)
            {
                currentWaypoint = 0;
                targetWaypoint = eventWayPoints[currentWaypoint];
            }
            */

            if (currentWaypoint == points.Count)
            {
                currentWaypoint = 0;
            }
            targetWaypoint = points[currentWaypoint];

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}