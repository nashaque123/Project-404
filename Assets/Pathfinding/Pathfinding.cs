using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{

    Grid grid;

    public Transform start, target;

    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    FindPath(start.position, target.position);
        //}
        FindPath(start.position, target.position);

    }
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        Node startingNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closeSet = new HashSet<Node>();

        openSet.Add(startingNode);

        while(openSet.Count > 0)
        {
            Node CurrentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < CurrentNode.fCost || openSet[i].fCost == CurrentNode.fCost && openSet[i].hCost < CurrentNode.hCost)
                {
                    CurrentNode = openSet[i];
                }
            }
            openSet.Remove(CurrentNode);
            closeSet.Add(CurrentNode);

            if (CurrentNode == targetNode)
            {
                //sw.Stop();
                //print("found Path in: " + sw.ElapsedMilliseconds + " ms");
                BackTrackPath(startingNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(CurrentNode))
            {
                if (!neighbour.moveable || closeSet.Contains(neighbour))
                {
                    continue;
                }


                int newMovementCostToNeighbour = CurrentNode.gCost + GetDistance(CurrentNode, neighbour);
                if(newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = CurrentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                        
                    
                }

            }
            
        }
    }

    void BackTrackPath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }
    int GetDistance(Node nodeA, Node nodeB)
    {
        int distanceX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distanceY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distanceX > distanceY)
            return 14 * distanceY + 10 * (distanceX - distanceY);
        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
   
}

