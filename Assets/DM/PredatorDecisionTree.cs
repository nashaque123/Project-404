using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorDecisionTree : MonoBehaviour
{
    private Animal thisAnimal;
    private AgentController thisAgent;
    private readonly float staminaThreshold = 20f;
    private readonly float growlRange = 10f;
    private readonly float staminaDrain = 2f;
    private readonly float restRate = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
        thisAgent = gameObject.GetComponent<AgentController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisAnimal.VisibleAgentsList.Count > 0)
        {
            if (Vector3.Distance(transform.position, thisAnimal.VisibleAgentsList[0].transform.position) < thisAnimal.AttackRange)
            {
                //attack
            }
            else
            {
                if (Random.Range(0, 30) == 0)
                {
                    //growl
                    Growl();
                }
                else
                {
                    //chase
                    thisAgent.Target = thisAnimal.VisibleAgentsList[0].gameObject;
                }
            }
        }
        else
        {
            if (thisAnimal.Stamina <= staminaThreshold)
            {
                //rest
                Rest();
            }
            else
            {
                //explore
                thisAgent.Target = null;
            }
        }
    }

    private void Growl()
    {
        Collider[] objectsWithinRange = Physics.OverlapSphere(thisAnimal.transform.position, growlRange);
        foreach (Collider collider in objectsWithinRange)
        {
            //check if collider is prey
            if (collider.gameObject.GetComponent<Animal>() != null && thisAnimal.PreyList.Contains(collider.gameObject.GetComponent<Animal>()))
            {
                collider.gameObject.GetComponent<Animal>().Stamina -= staminaDrain;
            }
        }
    }

    private void Rest()
    {
        thisAnimal.Stamina += restRate;
    }
}
