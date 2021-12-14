using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField] private Transform[] routes;
    [SerializeField] private float speedModifier = 0.25f;
    [SerializeField] private GameObject player;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float tParam = 0;

    private bool isNotStopped = false;
    private int routeToGo = 0;
    private Vector3 npcPosition = Vector3.zero;
    private bool coroutineAllowed;
    private float tParamHolder;

    private void Awake()
    {
        routeToGo = 0;
        tParam = 0f;
        //speedModifier = 0.25f;
        coroutineAllowed = true;
    }

    private void Update()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) < radius && coroutineAllowed)
        {
            Debug.Log("StartCoroutine!");
            //isNotStopped = true;
            StartCoroutine(GoByTheRoute(routeToGo));
        }
        else if(Vector3.Distance(this.transform.position, player.transform.position) > radius)
        {
            Debug.Log("StopCoroutine!");
            //isNotStopped = false;
            StopCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int _routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[_routeNumber].GetChild(0).position;
        Vector3 p1 = routes[_routeNumber].GetChild(1).position;
        Vector3 p2 = routes[_routeNumber].GetChild(2).position;
        Vector3 p3 = routes[_routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            npcPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            
            transform.position = npcPosition;

            //tParamHolder = tParam;

            yield return new WaitForEndOfFrame();
        }
        

        //tParamHolder = 0;
        tParam = 0f;

        routeToGo += 1;

        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}