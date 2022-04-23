using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flocking : MonoBehaviour
{
    public float radius = 10;
    public SphereCollider neighbourCollider;
    public int agentNumber = 5;
    public List<GameObject> neighbours;
    public Vector3 velocity;
    public Vector3 velocity2;

    public float alignmentFactor = 0.1f;
    public float cohesionFactor = 0.1f;
    public float seperationFactor = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        neighbourCollider = gameObject.GetComponent<SphereCollider>();
        neighbourCollider.radius = radius;
        neighbours = new List<GameObject>();
        velocity = new Vector3(Random.Range(0, 20f), Random.Range(0, 20f), Random.Range(0, 20f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(gameObject.name + " " + neighbours.Count);

        Vector3 alignment = new Vector3(0, 0, 0);
        //Alignment

        //for each agent
        foreach (GameObject neighbour in neighbours)
        {
            alignment += neighbour.GetComponent<flocking>().velocity;
        }

        //divide by number of agents
        if (neighbours.Count > 0)
        {
            alignment = alignment / neighbours.Count;
        }


        //Cohesion
        Vector3 cohesion = new Vector3(0, 0, 0);

        foreach (GameObject neighbour in neighbours)
        {
            cohesion += neighbour.transform.position;
            //cohesion += gameObject.transform.position - neighbour.transform.position;

        }

        if (neighbours.Count > 0)
        {
            cohesion = cohesion / neighbours.Count;
        }


        //Seperation
        Vector3 seperation = new Vector3(0, 0, 0);

        foreach (GameObject neighbour in neighbours)
        {
            seperation += gameObject.transform.position - neighbour.transform.position;
        }

        if (neighbours.Count > 0)
        {
            seperation = seperation / neighbours.Count;
        }


        velocity2 = (velocity + (alignmentFactor * alignment + cohesionFactor * cohesion + seperationFactor * seperation)) / 2;
        //Movement
        transform.Translate(velocity2 * Time.deltaTime);
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