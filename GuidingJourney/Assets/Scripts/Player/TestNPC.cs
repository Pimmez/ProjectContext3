using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : MonoBehaviour
{
    [SerializeField] private Transform points;                          //Control point parent
    private List<Transform> point_tranList = new List<Transform>();     //List of control points
    [SerializeField] private int pointCount = 100;                      //Number of curve points
    private List<Vector3> line_pointList;                               //Curve point list

    [SerializeField] private Transform lookTarget = null;                      //Look towards the goal
    [SerializeField] private GameObject ball;                           //Moving objects
    [SerializeField] private float time0 = 0;                           //Moving time interval between curve points
    private float timer = 0;                    //Timer
    private int item = 1;                       //Index of curve point
    private bool isTrue = false;

    //Make the ball move along a curve
    //Here you can’t directly use the difference calculation with Point in the for, and you can’t see the effect of the ball calculation
    //Define a timer to perform a difference calculation within the interval.
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        if (null != points && point_tranList.Count == 0)
        {
            foreach (Transform item in points)
            {
                point_tranList.Add(item);
            }
        }
        line_pointList = new List<Vector3>();
        for (int i = 0; point_tranList.Count != 0 && i < pointCount; i++)
        {
            //One
            Vector3 pos1 = Vector3.Lerp(point_tranList[0].position, point_tranList[1].position, i / (float)pointCount);
            Vector3 pos2 = Vector3.Lerp(point_tranList[1].position, point_tranList[2].position, i / (float)pointCount);
            Vector3 pos3 = Vector3.Lerp(point_tranList[2].position, point_tranList[3].position, i / (float)pointCount);
            Vector3 pos4 = Vector3.Lerp(point_tranList[3].position, point_tranList[4].position, i / (float)pointCount);
            Vector3 pos5 = Vector3.Lerp(point_tranList[4].position, point_tranList[5].position, i / (float)pointCount);

            //two
            var pos1_0 = Vector3.Lerp(pos1, pos2, i / (float)pointCount);
            var pos1_1 = Vector3.Lerp(pos2, pos3, i / (float)pointCount);
            var pos1_2 = Vector3.Lerp(pos3, pos4, i / (float)pointCount);
            var pos1_3 = Vector3.Lerp(pos4, pos5, i / (float)pointCount);
            //three
            var pos2_0 = Vector3.Lerp(pos1_0, pos1_1, i / (float)pointCount);
            var pos2_1 = Vector3.Lerp(pos1_1, pos1_2, i / (float)pointCount);
            var pos2_2 = Vector3.Lerp(pos1_2, pos1_3, i / (float)pointCount);
            //four
            var pos3_0 = Vector3.Lerp(pos2_0, pos2_1, i / (float)pointCount);
            var pos3_1 = Vector3.Lerp(pos2_1, pos2_2, i / (float)pointCount);
            //Fives
            Vector3 find = Vector3.Lerp(pos3_0, pos3_1, i / (float)pointCount);

            line_pointList.Add(find);
        }
        if (line_pointList.Count == pointCount)
            isTrue = true;
    }
    private void Update()
    {
        if (!isTrue)
            return;
        timer += Time.deltaTime;
        if (timer > time0)
        {
            timer = 0;
            if (item >= line_pointList.Count - 10)
            {
                ball.transform.LookAt(line_pointList[item]);
            }
            else
            {
                if (lookTarget)
                    ball.transform.LookAt(lookTarget);
                else
                    ball.transform.LookAt(line_pointList[item]);
            }
            ball.transform.localPosition = Vector3.Lerp(line_pointList[item - 1], line_pointList[item], 1f);
            item++;
            if (item >= line_pointList.Count)
                item = 1;
        }
    }

    //------------------------------------------------------------------------------
    //Show in scene view
    private void OnDrawGizmos()//Draw a line
    {
        Init();
        Gizmos.color = Color.yellow;
        for (int i = 0; i < line_pointList.Count - 1; i++)
        {
            Gizmos.DrawLine(line_pointList[i], line_pointList[i + 1]);
        }
    }
}