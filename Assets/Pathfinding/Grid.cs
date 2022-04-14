using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform StartingPos;
    public LayerMask ObstructionMask;
    public Vector2 gridWorldsize;
    public float nodeRadius;
    public float Distance;

    Node[,] grid;
    public List<Node> FinalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldsize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldsize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 BottomLeft = transform.position - Vector3.right * gridWorldsize.x / 2 - Vector3.forward * gridWorldsize.y / 2;
        for(int x = 0; x < gridSizeX; x++)
        {
            for(int y =0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = BottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool Obstruction = true;

                if(Physics.CheckSphere(worldPoint, nodeRadius, ObstructionMask))
                {
                    Obstruction = false;
                }

                grid[x, y] = new Node(Obstruction, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPos(Vector3 m_worldPos)
    {
        float xPoint = ((m_worldPos.x + gridWorldsize.x / 2) / gridWorldsize.x);
        float yPoint = ((m_worldPos.z + gridWorldsize.y / 2) / gridWorldsize.y);

        xPoint = Mathf.Clamp01(xPoint);
        yPoint = Mathf.Clamp01(yPoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xPoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPoint);
        return grid[x, y];
    }

    public List<Node> GetNeighbouringNodes(Node m_Node)
    {
        List<Node> NeighbouringNodes = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                //if we are on the node tha was passed in, skip this iteration.
                if (x == 0 && y == 0)
                {
                    continue;
                }

                int checkX = m_Node.gridPosX + x;
                int checkY = m_Node.gridPosY + y;

                //Make sure the node is within the grid.
                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    NeighbouringNodes.Add(grid[checkX, checkY]); //Adds to the neighbours list.
                }

            }
        }
        //int xCheck;
        //int yCheck;

        //// Right check
        //xCheck = m_Node.gridPosX + 1;
        //yCheck = m_Node.gridPosY;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighbouringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}
        //// left check
        //xCheck = m_Node.gridPosX - 1;
        //yCheck = m_Node.gridPosY;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighbouringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}


        //// top check
        //xCheck = m_Node.gridPosX;
        //yCheck = m_Node.gridPosY +1;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighbouringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}

        //// Bottom check
        //xCheck = m_Node.gridPosX;
        //yCheck = m_Node.gridPosY -1;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighbouringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}
        return NeighbouringNodes;
    }
           

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldsize.x, 1, gridWorldsize.y)); // draw wire cube with given dimensions.

        if (grid != null)// if not empty
        {
            foreach (Node node in grid) // loop through every node in grid
            {
                if (node.IsObstruction)
                {
                    Gizmos.color = Color.white;//set colour
                }
                else
                {
                    Gizmos.color = Color.yellow;//set colour
                }

                if(FinalPath != null)
                {
                    Gizmos.color = Color.red; // set colour
                    
                }

                Gizmos.DrawCube(node.Position, Vector3.one * (nodeDiameter - Distance)); // drawing the node at node position.
            }
        }
    }
}
