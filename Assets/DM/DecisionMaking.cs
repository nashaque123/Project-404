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
    private StateMachine state = StateMachine.eExplore;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
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
            }
            else if (thisAnimal.PreyList.Contains(otherAgent))
            {
                state = StateMachine.eAttack;
            }
        }

        //Debug.Log("list: " + gameObject.GetComponent<Animal>().VisibleAgentsList);
        Debug.Log(gameObject.name + " state: " + state);

        UpdateAction();
    }

    public void UpdateAction()
    {
        switch (state)
        {
            case StateMachine.eExplore:
                //walk about
                break;
            case StateMachine.eRest:
                //restore stamina
                break;
            case StateMachine.eAttack:
                //chase prey
                break;
            case StateMachine.eRun:
                //run away
                break;
            case StateMachine.eHide:
                //stay in hiding place
                break;
        }
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

        UpdateAction();
    }
}
