using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionMaking : MonoBehaviour
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
    
    //loop through list of visible agents and checks if they are in either list
    //updates state machine accordingly
    public void CheckListOfOtherAgents()
    {
        foreach (Animal otherAgent in gameObject.GetComponent<Animal>().VisibleAgentsList)
        {
            if (thisAnimal.PredatorList.Contains(otherAgent))
            {
                thisAnimal.State = StateMachine.eRun;
            }
            else if (thisAnimal.PreyList.Contains(otherAgent))
            {
                thisAnimal.State = StateMachine.eAttack;
            }
        }

        //Debug.Log("list: " + gameObject.GetComponent<Animal>().VisibleAgentsList);
        Debug.Log(gameObject.name + " state: " + thisAnimal.State);

        thisAnimal.UpdateAction();
    }
}
