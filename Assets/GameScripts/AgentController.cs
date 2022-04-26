using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    private Rigidbody rb;
    private Animal thisAnimal;
    private GameObject target;
    private bool isExploring = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        thisAnimal = gameObject.GetComponent<Animal>();
        transform.GetChild(0).gameObject.SetActive(true);
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
            thisAnimal.VisibleAgentsList.Remove(target.GetComponent<Animal>());
            target = null;
        }
    }

    void Explore()
    {
        //TODO: replace with flocking

        Vector3 moveInput = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        rb.AddForce((moveInput.normalized * thisAnimal.StepSize) - rb.velocity, ForceMode.VelocityChange);
        thisAnimal.Stamina -= thisAnimal.StaminaCost;
    }

    //check if other agent is within attacking range
    public bool PreyAgentWithinRange()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        //check if any objects are blocking path to agent
        if (Physics.Raycast(transform.position, direction, out RaycastHit raycast))
        {
            if (raycast.collider != null)
            {
                Transform collisionObject = GameObjectExtension.GetParentFromCollision(raycast.collider);
                if (collisionObject.GetComponent<Animal>() != null && thisAnimal.PreyList.Contains(collisionObject.GetComponent<ParentPrefab>().Source.GetComponent<Animal>())
                    && Vector3.Distance(transform.position, target.transform.position) <= thisAnimal.AttackRange)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Attack()
    {
        if (target != null && PreyAgentWithinRange() && thisAnimal.CanAttack)
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
