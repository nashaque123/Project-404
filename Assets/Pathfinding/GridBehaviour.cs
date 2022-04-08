using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{

    public int gridRows = 10;
    public int gridColumns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 bottomLeftLocation = new Vector3(0, 0, 0);
    public GameObject[,] gridArray;
    public int startingX = 0;
    public int startingY = 0;
    public int endingX = 5;
    public int endingY = 5;



    // Start is called before the first frame update
    void Awake()
    {
        gridArray = new GameObject[gridColumns, gridRows];
        if (gridPrefab)
            GridGeneration();
        else print("no prefab. assign prefab!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GridGeneration()
    {
        for (int i = 0; i < gridColumns; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(bottomLeftLocation.x + scale * i, bottomLeftLocation.y, bottomLeftLocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridInfo>().x = i;
                obj.GetComponent<GridInfo>().x = j;

                gridArray[i, j] = obj;
            }
        }
    }


    void SetDistance()
    {
        InitialSetUP();
        int x = startingX;
        int y = startingY;
        int[] testArray = new int[gridRows * gridColumns];
        for(int step = 1; step < gridRows * gridColumns; step++)
        {
            foreach(GameObject obj in gridArray)
            {
                if (obj.GetComponent<GridInfo>().traveledTo == step - 1)
                    TestFourDirections(obj.GetComponent<GridInfo>().x, obj.GetComponent<GridInfo>().y, step);
            }
        }
    }

    void InitialSetUP()
    {
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridInfo>().traveledTo = -1;
        }

        gridArray[startingX, startingY].GetComponent<GridInfo>().traveledTo = 0;

    }

    bool TestDirection(int x, int y, int step, int direction)
    {
        // in direction tells which case to use 1 = up, 2 right , 3 down and 4 left.
        switch (direction)
        {
            case 1:
                if (y + 1 < gridRows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridInfo>().traveledTo == step)
                    return true;
                else
                    return false;
            case 2:
                if (x + 1 < gridColumns && gridArray[x+1,y] && gridArray[x+1, y].GetComponent<GridInfo>().traveledTo == step)
                    return true;
                else
                    return false;

            case 3:
                if (y -1 < -1 && gridArray[x, y -1] && gridArray[x, y - 1].GetComponent<GridInfo>().traveledTo == step)
                    return true;
                else
                    return false;

            case 4:
                if (x-1 < -1 && gridArray[x -1, y] && gridArray[x-1, y].GetComponent<GridInfo>().traveledTo == step)
                    return true;
                else
                    return false;

        }
        return false;
    }

    void TestFourDirections(int x, int y, int step)
    {

    }
    void setUpTraveledTo(int x, int y, int step)
    {
        if (gridArray[x, y])
            gridArray[x, y].GetComponent<GridInfo>().traveledTo = step;

    }
}
  