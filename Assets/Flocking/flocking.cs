using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flocking : MonoBehaviour
{
    public float radius = 10;
    public SphereCollider neighbourCollider;
    public int agentNumber = 5;
    public List<GameObject> neighbours;

    // Start is called before the first frame update
    void Start()
    {
        neighbourCollider = gameObject.GetComponent<SphereCollider>();
        neighbourCollider.radius = radius;
        neighbours = new List<GameObject>();
        //Debug.Log(neighbours);
    }

    // Update is called once per frame
    void Update()
    {
        //Alignment

        //Cohesion

        //Seperation
    }

    void OnTriggerEnter(Collider collision)
    {
       Debug.Log(collision.gameObject.GetType());

        if (collision.gameObject.CompareTag("agent"))
        {
            //Debug.Log ("agent");
            neighbours.Add(collision.gameObject);
            //Debug.Log(neighbours.Count); 
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("agent"))
        {
            neighbours.Remove(collision.gameObject);
            //Debug.Log(neighbours.Count);
        }
    }

}
