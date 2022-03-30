using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public float MovementSpeed = 5.0f;

    private Stack<Vector3> activePath;
    private Vector3 activeWaypointPos;
    private float movingTimeTotal; // total time of movement
    private float movingTimeCurr; // the current time of movement 

    public void NavigateTo(Vector3 destination)
    {
        // A* Implemention

        activePath = new Stack<Vector3>();
        var activeNode = FindNearestWaypoint(transform.position);
        var endNode = FindNearestWaypoint(destination);
        if (activeNode == null || endNode == null || activeNode == endNode)
            return;

        var openList = new SortedList<float, Waypoints>();
        var closedList = new List<Waypoints>();

        openList.Add(0, activeNode);
        activeNode.previous = null;
        activeNode.distance = 0f;
        while (openList.Count > 0 )
        {
            activeNode = openList.Values[0];
            openList.RemoveAt(0);
            var dist = activeNode.distance;
            closedList.Add(activeNode);
            if (activeNode == endNode)
            {
                break;
            }
            foreach(var neighbour in activeNode.neighbours)
            {
                if (closedList.Contains(neighbour) || openList.ContainsValue(neighbour))
                    continue;
                neighbour.previous = activeNode;
                neighbour.distance = dist + (neighbour.transform.position - activeNode.transform.position).magnitude;
                var targetDistance = (neighbour.transform.position - endNode.transform.position).magnitude;
                openList.Add(neighbour.distance + targetDistance, neighbour);

                
            }
        }



    }
    public void Stop()
    {
        activePath = null;
        movingTimeTotal = 0;
        movingTimeCurr = 0;
    }

    void Update()
    {
        // follow path
        if (activePath != null && activePath.Count > 0)
        {
            if(movingTimeCurr < movingTimeTotal)
            {
                movingTimeCurr += Time.deltaTime;
                if (movingTimeCurr < movingTimeTotal)
                    movingTimeCurr = movingTimeTotal;
                transform.position = Vector3.Lerp(activeWaypointPos, activePath.Peek(), movingTimeCurr / movingTimeTotal);
            }
            else
            {
                activeWaypointPos = activePath.Pop();
                if (activePath.Count == 0)
                    Stop();
                else
                {
                    movingTimeCurr = 0;
                    movingTimeTotal = (activeWaypointPos - activePath.Peek()).magnitude / MovementSpeed;
                }
            }
        }
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



