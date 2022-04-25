using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateMachine
{
    eExplore,
    eRest,
    eAttack,
    eRun,
    eHide,
    eDead
}

public class HierarchicalStateMachine : MonoBehaviour
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
            State = StateMachine.eExplore;
        }
        else if (state == StateMachine.eAttack)
        {
            agentController.Attack();
        }
    }

    //loop through list of visible agents and checks if they are in either list
    //updates state machine accordingly
    public void CheckListOfOtherAgents()
    {
        foreach (Animal otherAgent in thisAnimal.VisibleAgentsList)
        {
            if (thisAnimal.PredatorList.Contains(otherAgent.gameObject.GetComponent<ParentPrefab>().Source.GetComponent<Animal>()))
            {
                if (agentController.Target == null ||
                    Vector3.Distance(transform.position, otherAgent.transform.position) < Vector3.Distance(transform.position, agentController.Target.transform.position))
                {
                    agentController.Target = otherAgent.gameObject;
                }

                State = StateMachine.eRun;
            }
            else if (thisAnimal.PreyList.Contains(otherAgent.GetComponent<ParentPrefab>().Source.GetComponent<Animal>()) && !state.Equals(StateMachine.eRun))
            {
                if (agentController.Target == null ||
                    Vector3.Distance(transform.position, otherAgent.transform.position) < Vector3.Distance(transform.position, agentController.Target.transform.position))
                {
                    agentController.Target = otherAgent.gameObject;
                }

                State = StateMachine.eAttack;
            }
        }
    }

    public void UpdateAction()
    {
        switch (state)
        {
            case StateMachine.eExplore:
                //walk about
                agentController.Target = null;
                agentController.IsExploring = true;
                break;
            case StateMachine.eRest:
                //restore stamina
                agentController.Target = null;
                agentController.IsExploring = false;
                break;
            case StateMachine.eAttack:
                //chase prey
                agentController.Attack();
                break;
            case StateMachine.eRun:
                agentController.Run();
                //run away
                break;
            case StateMachine.eHide:
                //go in hiding place
                agentController.EnterHidingSpot();
                break;
            case StateMachine.eDead:
                Destroy(gameObject);
                break;
        }
    }

    //change state to rest when stamina is low
    private void CheckStamina()
    {
        if (state == StateMachine.eExplore && thisAnimal.Stamina < 20)
        {
            State = StateMachine.eRest;
        }
        else if (state == StateMachine.eRest && thisAnimal.Stamina > 90)
        {
            State = StateMachine.eExplore;
        }
    }

    public void HidingSpotAvailable(GameObject hidingSpot)
    {
        //if being attacked, set hiding spot as target
        if (state == StateMachine.eRun)
        {
            agentController.Target = hidingSpot;
            State = StateMachine.eHide;
        }
    }

    private bool IsPredatorWithinRange()
    {
        Collider[] objectsWithinRange = Physics.OverlapSphere(thisAnimal.transform.position, 10f);
        foreach (Collider collider in objectsWithinRange)
        {
            //check if collider is prey
            if (collider.gameObject.GetComponent<Animal>() != null && thisAnimal.PredatorList.Contains(collider.gameObject.GetComponent<ParentPrefab>().Source.GetComponent<Animal>()))
            {
                return true;
            }
        }

        return false;
    }

    public StateMachine State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
            UpdateAction();
        }
    }
}
