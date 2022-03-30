using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreation : MonoBehaviour
{
    public Transform cells;
    [SerializeField] private int H;
    [SerializeField] private int W;
    private Node[,] nodes;
    // Start is called before the first frame update

    public void CreateGrid()
    {
        nodes = new Node[W, H];
        var name = 0;
        for(int i = 0; i < W; i++)
        {
            for(int j = 0; j < H; j++)
            {
                Vector3 worldPos = new Vector3(i, 0, j);
                Transform obj = Instantiate(cells, worldPos, Quaternion.identity);
                obj.name = "cells " + name;
                nodes[i, j] = new Node(true, worldPos, obj);
                name++;
            }
        }
    }

    public class Node
    {
        public bool placeable;
        public Vector3 cellsPos;
        public Transform obj;

        public Node(bool placeable, Vector3 cellsPos, Transform obj)
        {
            this.placeable = placeable;
            this.cellsPos = cellsPos;
            this.obj = obj;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
