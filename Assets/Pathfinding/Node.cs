using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
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
    //public int gridPosX; // X pos
    //public int gridPosY; // Y pos
    //public bool IsObstruction; // tells the program if there is an obstruction.
    //public Vector3 Position; // world pos of node.

    //public Node Parent; // used for A* algorithm, stores the prev node so can work out shortest path.

    //public int gCost; // cost of movement to the square.
    //public int hCost; // distance to goal from current node.
    //public int FCost { get { return gCost + hCost; } }

    //public Node(bool m_IsObstruction, Vector3 m_Pos, int m_GridX, int m_GridY) 
    //{
    //    IsObstruction = m_IsObstruction;
    //    Position = m_Pos;
    //    gridPosX = m_GridX;
    //    gridPosY = m_GridY;

    //}
}
