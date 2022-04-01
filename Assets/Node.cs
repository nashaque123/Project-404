using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    bool isAccsessible;
    List<Node> neigbours;
    List<GameObject> Obstructions;
    // Start is called before the first frame update
    void Start()
    {
        neigbours = new List<Node>();

        Obstructions = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        // get game object for collision

        //check if node tag in game object

        // get node component

        // add to neigbours

        // check if node is accsessible
        if (collision.gameObject.CompareTag("Node"))
        {
            neigbours.Add(collision.gameObject.GetComponent<Node>());

        }
        else if(collision.gameObject.CompareTag("Obstruction"))
        {
            Obstructions.Add(collision.gameObject);
        }

        isAccsessible = Obstructions.Count==0;
       

    }

    // collison exit
    // 
    
}
