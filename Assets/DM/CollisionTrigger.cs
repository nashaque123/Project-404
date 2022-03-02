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
            Debug.Log(gameObject.transform.parent.name + " colliding with " + other.gameObject.name);

            //check if other agent is visible using ray cast
            if (Physics.Raycast(gameObject.transform.position, other.gameObject.transform.position, out RaycastHit raycast))
            {
                Debug.Log("raycast collider: " + raycast.collider);
                Debug.DrawLine(transform.position, raycast.collider.transform.position, Color.black, 5f, false);
                //if other agent is visible then add to list
                if (raycast.collider != null && raycast.collider.gameObject.GetComponentInParent<Animal>() != null)
                {
                    thisAnimal.VisibleAgentsList.Add(raycast.collider.gameObject.GetComponentInParent<Animal>());
                    gameObject.GetComponentInParent<DecisionMaking>().CheckListOfOtherAgents();
                    Debug.Log(raycast.collider.transform.parent + " visible");
                }
            }
        }
    }

    //other agent leaves bubble
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.Equals(parentObject))
        {
            Debug.Log(gameObject.transform.parent.name + " not colliding with " + other.gameObject.name);

            //if other agent is in list then remove
            if (thisAnimal.VisibleAgentsList.Contains(other.gameObject.GetComponentInParent<Animal>()))
            {
                thisAnimal.VisibleAgentsList.Remove(other.gameObject.GetComponentInParent<Animal>());
                gameObject.GetComponentInParent<DecisionMaking>().CheckListOfOtherAgents();
            }
        }
    }
}
