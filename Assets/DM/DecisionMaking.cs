using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateMachine
{
    eExplore,
    eRest,
    eAttack,
    eRun,
    eHide
}

public class DecisionMaking : MonoBehaviour
{
    private Animal thisAnimal;
    private AgentController agentController;
    private StateMachine state = StateMachine.eExplore;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
        agentController = gameObject.GetComponent<AgentController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStamina();
        if (state == StateMachine.eHide && !IsPredatorWithinRange())
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            state = StateMachine.eExplore;
            agentController.UpdateAction(state);
        }
    }

    //loop through list of visible agents and checks if they are in either list
    //updates state machine accordingly
    public void CheckListOfOtherAgents()
    {
        foreach (Animal otherAgent in thisAnimal.VisibleAgentsList)
        {
            if (thisAnimal.PredatorList.Contains(otherAgent))
            {
                state = StateMachine.eRun;

                if (agentController.Target == null ||
                    Vector3.Distance(transform.position, otherAgent.transform.position) < Vector3.Distance(transform.position, agentController.Target.transform.position))
                {
                    agentController.Target = otherAgent.gameObject;
                }
            }
            else if (thisAnimal.PreyList.Contains(otherAgent) && !state.Equals(StateMachine.eRun))
            {
                state = StateMachine.eAttack;

                if (agentController.Target == null ||
                    Vector3.Distance(transform.position, otherAgent.transform.position) < Vector3.Distance(transform.position, agentController.Target.transform.position))
                {
                    agentController.Target = otherAgent.gameObject;
                }
            }
        }

        agentController.UpdateAction(state);
    }

    //change state to rest when stamina is low
    private void CheckStamina()
    {
        if (state == StateMachine.eExplore && thisAnimal.Stamina < 20)
        {
            state = StateMachine.eRest;
        }
        else if (state == StateMachine.eRest && thisAnimal.Stamina > 90)
        {
            state = StateMachine.eExplore;
        }

        agentController.UpdateAction(state);
    }

    public void HidingSpotAvailable(GameObject hidingSpot)
    {
        //if being attacked, set hiding spot as target
        if (state == StateMachine.eRun)
        {
            agentController.Target = hidingSpot;
            state = StateMachine.eHide;
            agentController.UpdateAction(state);
        }
    }

    private bool IsPredatorWithinRange()
    {
        Collider[] objectsWithinRange = Physics.OverlapSphere(thisAnimal.transform.position, 10f);
        foreach (Collider collider in objectsWithinRange)
        {
            //check if collider is prey
            if (collider.gameObject.GetComponent<Animal>() != null && thisAnimal.PredatorList.Contains(collider.gameObject.GetComponent<Animal>()))
            {
                return true;
            }
        }

        return false;
    }
}
