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

                if (Vector3.Distance(transform.position, otherAgent.transform.position) < Vector3.Distance(transform.position, agentController.Target.transform.position))
                {
                    agentController.Target = otherAgent.gameObject;
                }
            }
            else if (thisAnimal.PreyList.Contains(otherAgent) && !state.Equals(StateMachine.eRun))
            {
                state = StateMachine.eAttack;

                if (Vector3.Distance(transform.position, otherAgent.transform.position) < Vector3.Distance(transform.position, agentController.Target.transform.position))
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
}
