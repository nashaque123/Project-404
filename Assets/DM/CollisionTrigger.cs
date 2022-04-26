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

    //other agent collides with bubble
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            Vector3 raycastDirection = (other.gameObject.transform.position - gameObject.transform.position).normalized;
            //check if other agent is visible using ray cast
            if (Physics.Raycast(gameObject.transform.position, raycastDirection, out RaycastHit raycast))
            {
                //if other object is visible then check what it is
                if (raycast.collider != null)
                {
                    Transform collisionObject = GameObjectExtension.GetParentFromCollision(raycast.collider);

                    //if agent then add to list
                    if (collisionObject.gameObject.GetComponent<Animal>() != null)
                    {
                        thisAnimal.VisibleAgentsList.Add(collisionObject.gameObject.GetComponent<Animal>());
                        if (gameObject.GetComponentInParent<HierarchicalStateMachine>() != null)
                        {
                            gameObject.GetComponentInParent<HierarchicalStateMachine>().CheckListOfOtherAgents();
                        }
                    }
                    else if (collisionObject.gameObject.layer == 7) //check if object has hiding spot layer
                    {
                        thisAnimal.VisibleHidingSpotList.Add(collisionObject.gameObject);
                        if (gameObject.GetComponentInParent<HierarchicalStateMachine>() != null)
                        {
                            gameObject.GetComponentInParent<HierarchicalStateMachine>().HidingSpotAvailable(collisionObject.gameObject);
                        }
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
            Transform agent = GameObjectExtension.GetParentFromCollision(other);

            //if other agent is in list then remove
            if (agent.GetComponent<Animal>() != null)
            {
                if (thisAnimal.VisibleAgentsList.Contains(agent.gameObject.GetComponent<Animal>()))
                {
                    thisAnimal.VisibleAgentsList.Remove(agent.gameObject.GetComponent<Animal>());
                    if (gameObject.GetComponentInParent<HierarchicalStateMachine>() != null)
                    {
                        gameObject.GetComponentInParent<HierarchicalStateMachine>().CheckListOfOtherAgents();
                    }
                }
            }
            else if (agent.gameObject.layer == 7)
            {
                if (thisAnimal.VisibleHidingSpotList.Contains(agent.gameObject))
                {
                    thisAnimal.VisibleHidingSpotList.Remove(agent.gameObject);
                }
            }
        }
    }
}
