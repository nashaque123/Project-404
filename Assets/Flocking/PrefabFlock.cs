using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFlock : MonoBehaviour
{
    public List<PrefabFlock> Cneighbours = new List<PrefabFlock>();
    [SerializeField] public float FOV;
    private Flocking2 flock;

    public Vector3 thisVelocity;
    public Transform thisTransform { get; set; }
    [SerializeField] private float smoothDamp;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Cneighbours = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        thisTransform = transform;
    }

    public void move()
    {
        neighboursLoc();
        var CVect = cohesionCalc();
        var movementVect = Vector3.SmoothDamp(thisTransform.forward, CVect, ref thisVelocity, smoothDamp);
        movementVect = movementVect.normalized * speed;
        thisTransform.forward = movementVect;
        thisTransform.position += movementVect * Time.deltaTime;
    }

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
            if (FOVSeen(Cneighbours[i].thisTransform.position))
            {
                FOVneighbours += 1;
                CVect += Cneighbours[i].thisTransform.position;
            }
        }

        if (FOVneighbours == 0)
        {
            return CVect;
        }

        CVect /= FOVneighbours;
        CVect -= thisTransform.position;
        CVect = Vector3.Normalize(CVect);
        return CVect;
        //return CVect;
    }

    public bool FOVSeen(Vector3 position)
    {
        return Vector3.Angle(thisTransform.forward, position - thisTransform.position) <= FOV;
    }

    private void neighboursLoc()
    {
        Cneighbours.Clear();
        var units = flock.unitsvar;

        for(int i = 0; i < units.Length; i++)
        {
            var thisUnit = units[i];
            if (thisUnit != this)
            {
                float thisAgentDist = Vector3.SqrMagnitude(thisUnit.transform.position - transform.position);
                if (thisAgentDist <= flock.CDist1 * flock.CDist1)
                {
                    Cneighbours.Add(thisUnit);
                }
            }
        }

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
