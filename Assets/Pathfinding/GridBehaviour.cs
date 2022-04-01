using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{

    public int gridRows = 10;
    public int gridColumns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 bottomLeftLocation = new Vector3(0,0,0);


    // Start is called before the first frame update
    void Awake()
    {
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
                GameObject obj = Instantiate(gridPrefab, new Vector3(bottomLeftLocation.x + scale * i, bottomLeftLocation.y, bottomLeftLocation.z + scale * j),Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridInfo>().x = i;
                obj.GetComponent<GridInfo>().x = j;
            }
        }
    }
}
