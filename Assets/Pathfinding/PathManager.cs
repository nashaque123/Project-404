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
        activePath = new Stack<Vector3>();
        var activeNode = FindNearestWaypoint(transform.position);
        var endNode = FindNearestWaypoint(destination);
        if (activeNode == null || endNode == null || activeNode == endNode)
            return;

        var openList = new SortedList<float, Waypoints>();
        var closedList = new List<Waypoints>();

        openList.Add(0, activeNode);
        activeNode.previous = null;
        //activeNode.distance = 0f;

    }
    public void Stop() { }

    void Update()
    {

    }

 
    private Waypoints FindNearestWaypoint(Vector3 target)
    {
        GameObject nearest = null;
        float nearestDist = Mathf.Infinity;
        foreach (var waypoint in GameObject.FindGameObjectsWithTag("Waypoints"))
        {
            var dist = (waypoint.transform.position - target).magnitude;
            if (dist < nearestDist)
            {
                nearest = waypoint;
                nearestDist = dist;
            }
        }
        if (nearest != null)
        {
            return nearest.GetComponent<Waypoints>();
        }
        return null;

    }
}



