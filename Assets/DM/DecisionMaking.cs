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
    private StateMachine state = StateMachine.eExplore;
    private int stamina, health;
    //private List<Agent> otherAgents;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     *  void move() {
     *      change position;
     *      reduce stamina;
     *      change state to rest when stamina is low
     *      
     *      updateAction()
     *  } 
     *  
     *  
     *  void checkList() {
     *      loop through list of visible agents
     *      if otherAgent is in predatorList then state = run
     *      
     *      else if otherAgent is in preyList then state = attack
     *      
     *      updateAction()
     *  }
     *  
     *  void updateAction() {
     *      switch(state) {
     *          case explore:
     *              walk about
     *          case rest:
     *              restore stamina
     *          case attack:
     *              chase prey
     *              
     *      }
     *  }
     */
}
