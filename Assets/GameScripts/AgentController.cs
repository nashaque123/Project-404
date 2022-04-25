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
        else if (target.GetComponent<MeshRenderer>().enabled == false)
        {
            target = null;
        }
    }

    void Explore()
    {
        //replace with flocking
        /*Vector3 moveInput = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        rb.MovePosition(rb.position + (thisAnimal.StepSize * Time.deltaTime * moveInput.normalized));
        thisAnimal.Stamina -= thisAnimal.StaminaCost;*/
    }

    //check if other agent is within attacking range
    public bool PreyAgentWithinRange()
    {
        //check if any objects are blocking path to agent
        if (Physics.Raycast(transform.position, target.transform.position, out RaycastHit raycast))
        {
            if (raycast.collider != null)
            {
                Transform collisionObject = GameObjectExtension.GetParentFromCollision(raycast.collider);

                if (collisionObject.GetComponent<Animal>() != null && collisionObject.Equals(target) && Vector3.Distance(transform.position, target.transform.position) <= thisAnimal.AttackRange)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Attack()
    {
        if (PreyAgentWithinRange() && thisAnimal.CanAttack)
        {
            StartCoroutine(thisAnimal.Attack(target.GetComponent<Animal>()));
        }
    }

    public void Run()
    {
        if (CheckForHidingSpot())
        {
            EnterHidingSpot();
        }
    }

    public void EnterHidingSpot()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        thisAnimal.Stamina += 0.15f;
        thisAnimal.Health += 0.15f;
    }

    private bool CheckForHidingSpot()
    {
        return thisAnimal.VisibleHidingSpotList.Count > 0;
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

    public bool IsExploring
    {
        get
        {
            return isExploring;
        }

        set
        {
            isExploring = value;
        }
    }
}
