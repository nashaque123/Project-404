using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : HeapItem<Node>
{
    public bool moveable;
    public Vector3 worldPos;
    public int gCost; // cost of movement to the square.
    public int hCost; // distance to goal from current node.
    public int gridX;
    public int gridY;
    public Node parent;
   

    public Node(bool m_canMovethrough, Vector3 m_worldPos, int m_gridX, int m_gridY)
    {
        moveable = m_canMovethrough;
        worldPos = m_worldPos;
        gridX = m_gridX;
        gridY = m_gridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }

    public int HeapIndex
    {
        get
        {
            return HeapIndex;
        }
        set
        {
            HeapIndex = value;
        }
    }

    public int CompareTo(Node compareNode)
    {
        int compare = fCost.CompareTo(compareNode.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(compareNode.hCost);
        }
        return -compare;
    }

}
