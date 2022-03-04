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

public class Animal : MonoBehaviour
{
    private StateMachine state = StateMachine.eExplore;
    private int stamina, health;
    private List<Animal> visibleAgentsList;

    [SerializeField]
    private List<Animal> predatorList;

    [SerializeField]
    private List<Animal> preyList;


    // Start is called before the first frame update
    void Start()
    {
        visibleAgentsList = new List<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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


    void Move()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-0.5f, 0.5f));
        //change position;
        //reduce stamina;
        //change state to rest when stamina is low

        //updateAction();
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
        }
    }

    public List<Animal> VisibleAgentsList
    {
        get
        {
            return visibleAgentsList;
        }
    }

    public List<Animal> PredatorList
    {
        get
        {
            return predatorList;
        }
    }

    public List<Animal> PreyList
    {
        get
        {
            return preyList;
        }
    }
}
