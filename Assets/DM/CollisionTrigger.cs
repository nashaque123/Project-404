using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private Animal thisAnimal;
    private GameObject parentObject;

    [SerializeField]
    private LayerMask collidableLayers;

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
            if (Physics.Raycast(gameObject.transform.position, other.gameObject.transform.position, out RaycastHit raycast, Mathf.Infinity, collidableLayers))
            {
                Debug.Log("raycast collider: " + raycast.collider);
                //if other agent is visible then add to list
                if (raycast.collider != null && raycast.collider.gameObject.GetComponent<Animal>() != null)
                {
                    thisAnimal.VisibleAgentsList.Add(raycast.collider.gameObject.GetComponent<Animal>());
                    gameObject.GetComponent<DecisionMaking>().CheckListOfOtherAgents();
                    Debug.Log("visible");
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
            if (thisAnimal.VisibleAgentsList.Contains(other.gameObject.GetComponent<Animal>()))
            {
                thisAnimal.VisibleAgentsList.Remove(other.gameObject.GetComponent<Animal>());
                gameObject.GetComponent<DecisionMaking>().CheckListOfOtherAgents();
            }
        }
    }
}
