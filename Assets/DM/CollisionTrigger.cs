using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    Animal thisAnimal;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //other agent collides with bubble
    private void OnTriggerEnter(Collider other)
    {
        //check if other agent is visible using ray cast
        if (Physics.Raycast(gameObject.transform.position, other.transform.position, out RaycastHit raycast))
        {
            //if other agent is visible then add to list
            if (raycast.collider != null && raycast.collider.gameObject.GetComponent<Animal>() != null)
            {
                thisAnimal.VisibleAgentsList.Add(raycast.collider.gameObject.GetComponent<Animal>());
                gameObject.GetComponent<DecisionMaking>().CheckListOfOtherAgents();
            }
        }
    }

    //other agent leaves bubble
    private void OnTriggerExit(Collider other)
    {
        //if other agent is in list then remove
        if (thisAnimal.VisibleAgentsList.Contains(other.gameObject.GetComponent<Animal>()))
        {
            thisAnimal.VisibleAgentsList.Remove(other.gameObject.GetComponent<Animal>());
            gameObject.GetComponent<DecisionMaking>().CheckListOfOtherAgents();
        }
    }
}
