using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFlock : MonoBehaviour
{
    //CNeighbours is where the agents classed as neighbours are stored
    public List<PrefabFlock> Cneighbours = new List<PrefabFlock>();
    [SerializeField] public float FOV;
    private Flocking2 flock;

    public Vector3 thisVelocity;
    public Transform thisTransform { get; set; }
    //The smaller the SmoothDamp value, the more accurate the code value is
    [SerializeField] private float smoothDamp;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        thisTransform = transform;
    }

    //This is in charge of moving the agents
    public void move()
    {
        //This gets all the neighbours locations and then moves/tranforms them to where they should be using delta time
        neighboursLoc();
        var CVect = cohesionCalc();
        //SmoothDamp gradually changes a value over time
        var movementVect = Vector3.SmoothDamp(thisTransform.forward, CVect, ref thisVelocity, smoothDamp);
        movementVect = movementVect.normalized * speed;
        thisTransform.forward = movementVect;
        thisTransform.position += movementVect * Time.deltaTime;
    }

    //This function works out the cohesion vector
    private Vector3 cohesionCalc()
    {
        var CVect = new Vector3 (0, 0, 0);
        int FOVneighbours = 0;

        if (Cneighbours.Count == 0)
        {
            return CVect;
        }

        for (int i = 0; i < Cneighbours.Count; i += 1)
        {
            //This checks which neighbours are in the field of view
            if (FOVSeen(Cneighbours[i].thisTransform.position))
            {
               //Adds the neighbours that are in the field of view and adds them to cohesion vector
                FOVneighbours += 1;
                CVect += Cneighbours[i].thisTransform.position;
            }
        }

        if (FOVneighbours == 0)
        {
            return CVect;
        }

        //This works out where the agents need to be
        CVect /= FOVneighbours;
        CVect -= thisTransform.position;
        CVect = Vector3.Normalize(CVect);
        return CVect;
    }

    private void neighboursLoc()
    {
        Cneighbours.Clear();
        var units = flock.unitsvar;

        for (int i = 0; i < units.Length; i++)
        {
            //Sets the unit currently being checked to a new variable temporarily
            var thisUnit = units[i];

            //If it's being checked against another agent
            if (thisUnit != this)
            {
                //If it is close enough, the agent will be added as a neighbour
                float thisAgentDist = Vector3.SqrMagnitude(thisUnit.transform.position - transform.position);
                if (thisAgentDist <= flock.CDist1 * flock.CDist1)
                {
                    Cneighbours.Add(thisUnit);
                }
            }
        }
    }

    public bool FOVSeen(Vector3 position)
    {
        //Works out if the agent is in the field of view
        if (Vector3.Angle(thisTransform.forward, position - thisTransform.position) <= FOV)
        {
            return true;
        }

        else return false;
    }

    public void flockFunc(Flocking2 flock1)
    {
        flock = flock1;
    }

    public void startSpeed(float speed)
    {
        this.speed = speed;
    }
}
