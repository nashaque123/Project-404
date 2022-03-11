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
                Transform collisionObject = GetParentFromCollision(raycast.collider);
                Debug.Log("raycast collider: " + collisionObject);
                Debug.DrawLine(transform.position, collisionObject.position, Color.black, 5f, false);

                //if other object is visible then check what it is
                if (raycast.collider != null)
                {
                    //if agent then add to list
                    if (collisionObject.gameObject.GetComponent<Animal>() != null)
                    {
                        thisAnimal.VisibleAgentsList.Add(collisionObject.gameObject.GetComponent<Animal>());
                        gameObject.GetComponentInParent<DecisionMaking>().CheckListOfOtherAgents();
                        Debug.Log(collisionObject + " visible");
                    }
                    else if (collisionObject.gameObject.CompareTag("Hiding spot"))
                    {
                        Debug.Log("visible hiding spot " + collisionObject);
                    }
                }
            }
        }
    }

    //other agent leaves bubble
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            Transform agent = GetParentFromCollision(other);

            //if other agent is in list then remove
            if (thisAnimal.VisibleAgentsList.Contains(agent.gameObject.GetComponent<Animal>()))
            {
                thisAnimal.VisibleAgentsList.Remove(agent.gameObject.GetComponent<Animal>());
                //gameObject.GetComponentInParent<DecisionMaking>().CheckListOfOtherAgents();
            }
        }
    }

    private Transform GetParentFromCollision(Collider collider)
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
