using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    private Rigidbody rb;
    private Animal thisAnimal;
    private GameObject target;
    private bool isExploring;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        thisAnimal = gameObject.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (isExploring)
            {
                Explore();
            }
            else
            {
                //rest
                thisAnimal.Stamina += 0.1f;
            }
        }
    }

    void Explore()
    {
        Vector3 moveInput = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        rb.MovePosition(rb.position + (thisAnimal.StepSize * Time.deltaTime * moveInput.normalized));
        thisAnimal.Stamina -= thisAnimal.StaminaCost;
    }

    public void UpdateAction(StateMachine state)
    {
        switch (state)
        {
            case StateMachine.eExplore:
                //walk about
                target = null;
                isExploring = true;
                break;
            case StateMachine.eRest:
                //restore stamina
                target = null;
                isExploring = false;
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

    public GameObject Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }    
}