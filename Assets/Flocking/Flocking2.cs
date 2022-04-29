using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking2 : MonoBehaviour
{
    //I have used SerializeField to make them changeable in the inspector
    //I used PrefabFlock instead of GameObject to link both scripts together
    [SerializeField] private PrefabFlock flockingPrefab;
    [SerializeField] private int agentsNum;
    [SerializeField] private Vector3 boundaries;
    public PrefabFlock[] unitsvar { get; set; }

    [Range(0, 10)]
    [SerializeField] private float CDist;
    public float CDist1 { get { return CDist; } }

    [Range(0, 10)]
    public float maxSpeed;
    [Range(0, 10)]
    public float minSpeed;

    // Start is called before the first frame update
    void Start()
    {
        units();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Every frame it is checking all of the agents and moving them accordingly
        for (int i = 0; i < unitsvar.Length; i += 1)
        {
            Debug.Log(unitsvar[i]);
            unitsvar[i].move(); 
        }
    }

    //Spawns agents
    public void units()
    {
        unitsvar = new PrefabFlock[agentsNum];
        for (int i = 0; i < agentsNum; i++)
        {
            //Gets the spawn position
            var randVec = UnityEngine.Random.insideUnitSphere;
            randVec = new Vector3(randVec.x * boundaries.x, randVec.y * boundaries.y, randVec.z * boundaries.z);
            var spawnLoc = transform.position + randVec;

            //This adds new agents in (the quarternion part was for when they were meant to be changed from balls
            //into an animal/insect later)
            unitsvar[i] = Instantiate(flockingPrefab, spawnLoc, Quaternion.identity);
            unitsvar[i].flockFunc(this);
            unitsvar[i].startSpeed(UnityEngine.Random.Range(minSpeed, maxSpeed));
        }
    }
}
