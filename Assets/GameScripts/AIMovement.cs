using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private AgentController agentController;
    private Animal thisAnimal;
    private Rigidbody thisRb;
    private Pathfinding pathfindingManager;
    private List<Node> path;

    // Start is called before the first frame update
    void Start()
    {
        agentController = gameObject.GetComponent<AgentController>();
        thisAnimal = gameObject.GetComponent<Animal>();
        thisRb = gameObject.GetComponent<Rigidbody>();
        pathfindingManager = GameObject.Find("A*").GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agentController.Target != null)
        {
            //update path in case target is moving
            //if (Time.frameCount % 10 == 0)
            {
                path = pathfindingManager.FindPath(transform.position, agentController.Target.transform.position);
            }

            //check if path has nodes to move to
            if (path.Count > 1)
            {
                MoveTowardsTarget();
            }
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 directionToTarget = new Vector3(path[1].worldPos.x - transform.position.x, 0f, path[1].worldPos.z - transform.position.z).normalized;
        thisRb.MovePosition(thisRb.position + (thisAnimal.StepSize * Time.deltaTime * directionToTarget));
        thisAnimal.Stamina -= thisAnimal.StaminaCost;
    }
}
