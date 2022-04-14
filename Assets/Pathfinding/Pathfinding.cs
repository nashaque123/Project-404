using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid grid;
    public Transform StartingPos;
    public Transform TargetPos;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    private void Update()
    {
        FindPath(StartingPos.position, TargetPos.position);
    }

    void FindPath(Vector3 m_startPos,Vector3 m_TargetPos)
    {
        Node StartingNode = grid.NodeFromWorldPos(m_startPos); 
        Node targetNode = grid.NodeFromWorldPos(m_TargetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartingNode);

        while(OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
            {
                if(OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if(CurrentNode == targetNode)
            {
                GetFinalPath(StartingNode, targetNode);
                
            }
            

            foreach(Node NeighbourNode in grid.GetNeighbouringNodes(CurrentNode))
            {
                if(!NeighbourNode.IsObstruction || ClosedList.Contains(NeighbourNode))
                {
                    continue;
                }
                int movementCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighbourNode);

                if(movementCost < NeighbourNode.gCost || !OpenList.Contains(NeighbourNode))
                {
                    NeighbourNode.gCost = movementCost;
                    NeighbourNode.hCost = GetManhattenDistance(NeighbourNode, targetNode);
                    NeighbourNode.Parent = CurrentNode;

                    if(!OpenList.Contains(NeighbourNode))
                    {
                        OpenList.Add(NeighbourNode);
                    }
                }
            }
        }
    }


    void GetFinalPath(Node m_StartingNode, Node m_EndingNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = m_EndingNode;

        while(CurrentNode != m_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }
        FinalPath.Reverse();

        grid.FinalPath = FinalPath;
    }

    int GetManhattenDistance(Node m_NodeA,Node m_NodeB)
    {
        int ix = Mathf.Abs(m_NodeA.gridPosX - m_NodeB.gridPosX);
        int iy = Mathf.Abs(m_NodeA.gridPosY - m_NodeB.gridPosY);

        return ix + iy;
    }
}

