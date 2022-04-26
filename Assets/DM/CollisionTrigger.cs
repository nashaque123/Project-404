using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private Animal thisAnimal;
    private GameObject parentObject;
    private List<GameObject> objectsInArea = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponentInParent<Animal>();
        parentObject = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        CleanObjectsInAreaList();
        foreach (GameObject obj in objectsInArea)
        {
            if (IsObjectVisible(obj, out Collider collider))
            {
                AddVisibleObjectToList(collider);
            }
        }
    }

    //other agent collides with bubble
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            objectsInArea.Add(other.gameObject);

            if (IsObjectVisible(other.gameObject, out Collider collider))
            {
                AddVisibleObjectToList(collider);
            }
        }
    }

    private bool IsObjectVisible(GameObject obj, out Collider raycastCollider)
    {
        raycastCollider = null;
        Vector3 raycastDirection = (obj.transform.position - gameObject.transform.position).normalized;
        //check if other agent is visible using ray cast
        if (Physics.Raycast(gameObject.transform.position, raycastDirection, out RaycastHit raycast))
        {
            //if other object is visible then check what it is
            if (raycast.collider != null)
            {
                raycastCollider = raycast.collider;
                return true;
            }
        }
        return false;
    }

    private void AddVisibleObjectToList(Collider collider)
    {
        Transform collisionObject = GameObjectExtension.GetParentFromCollision(collider);

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

    //other agent leaves bubble
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            objectsInArea.Remove(other.gameObject);
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

    private void CleanObjectsInAreaList()
    {
        for (int i = objectsInArea.Count - 1; i >= 0; i--)
        {
            if (objectsInArea[i] == null)
            {
                objectsInArea.RemoveAt(i);
            }
        }
    }
}