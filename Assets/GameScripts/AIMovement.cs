using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private AgentController agentController;
    private Pathfinding pathfindingManager;
    private List<Node> path;
    private int currentNodeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agentController = gameObject.GetComponent<AgentController>();
        pathfindingManager = GameObject.Find("A*").GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        path = pathfindingManager.FindPath(transform.position, agentController.Target.transform.position);
    }

    public List<Node> Path
    {
        get
        {
            return path;
        }

        set
        {
            path = value;
        }
    }
}
