using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private Animal thisAnimal;
    private GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponentInParent<Animal>();
        parentObject = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //other agent collides with bubble
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            //check if other agent is visible using ray cast
            if (Physics.Raycast(gameObject.transform.position, other.gameObject.transform.position, out RaycastHit raycast))
            {
                Transform agent = GetAgentFromCollision(raycast.collider);
                Debug.Log("raycast collider: " + agent);
                Debug.DrawLine(transform.position, agent.position, Color.black, 5f, false);

                //if other agent is visible then add to list
                if (raycast.collider != null && agent.gameObject.GetComponent<Animal>() != null)
                {
                    thisAnimal.VisibleAgentsList.Add(agent.gameObject.GetComponent<Animal>());
                    gameObject.GetComponentInParent<DecisionMaking>().CheckListOfOtherAgents();
                    Debug.Log(agent + " visible");
                }
            }
        }
    }

    //other agent leaves bubble
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            Transform agent = GetAgentFromCollision(other);

            //if other agent is in list then remove
            if (thisAnimal.VisibleAgentsList.Contains(agent.gameObject.GetComponent<Animal>()))
            {
                thisAnimal.VisibleAgentsList.Remove(agent.gameObject.GetComponent<Animal>());
                //gameObject.GetComponentInParent<DecisionMaking>().CheckListOfOtherAgents();
            }
        }
    }

    private Transform GetAgentFromCollision(Collider collider)
    {
        if (collider.transform.parent != null)
        {
            return collider.transform.parent;
        }
        else
        {
            return collider.transform;
        }
    }
}
