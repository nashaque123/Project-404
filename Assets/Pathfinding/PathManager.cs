using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public float MovementSpeed = 2.5f;

    private Stack<Vector3> activePath;
    private Vector3 activeWaypointPos;
    private float movingTimeTotal; // total time of movement
    private float movingTimeCurr; // the current time of movement 

    public void NavigateTo(Vector3 destination)
    {
        //activePath = new Stack<Vector3>();
        //var activeNode = FindNearestWaypoint(transform.position);
        //var endNode = FindNearestWaypoint(destination);
        //if (activeNode == null || endNode == null || activeNode == endNode)
        //    return;

    }
    public void Stop() { }

    void Update()
    {

    }

    //private Waypoints FindNearestWaypoint(Vector3 target)
    //{
    //    GameObject nearest = null;
    //    float nearestDistance = Mathf.Infinity;
    //    foreach (var waypoints in GameObject.FindGameObjectsWithTag("Waypoint"))
    //    {
    //        var distance = (waypoints.transform.position - target).magnitude;
    //        if (distance < nearestDistance)
    //        {
    //            nearest = waypoints;
    //            nearestDistance = distance;
    //        }
    //        if (nearest != null)
    //        {
    //            return nearest.GetComponent<Waypoints>();
    //        }
    //        return null;
    //    }

    //}

}



