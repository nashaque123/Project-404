using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorDecisionTree : MonoBehaviour
{
    private Animal thisAnimal;
    private AgentController thisAgent;
    private readonly float staminaThreshold = 20f;
    private readonly float growlRange = 10f;
    private readonly float staminaDrain = 2f;
    private readonly float restRate = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
        thisAgent = gameObject.GetComponent<AgentController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisAnimal.VisibleAgentsList.Count > 0)
        {
            Animal target = GetTarget();
            if (target == null)
            {
                Idle();
                return;
            }

            if (Vector3.Distance(transform.position, target.transform.position) < thisAnimal.AttackRange)
            {
                //attack
                if (thisAnimal.CanAttack)
                {
                    StartCoroutine(thisAnimal.Attack(target));
                    if (target.Health == 0)
                    {
                        thisAgent.Target = null;
                        thisAnimal.VisibleAgentsList.Remove(target);
                    }
                }
            }
            else
            {
                if (Random.Range(0, 30) == 0)
                {
                    //growl
                    Growl();
                }
                else
                {
                    //chase
                    thisAgent.Target = target.gameObject;
                }
            }
        }
        else
        {
            Idle();
        }
    }

    private void Growl()
    {
        Collider[] objectsWithinRange = Physics.OverlapSphere(thisAnimal.transform.position, growlRange);
        foreach (Collider collider in objectsWithinRange)
        {
            //check if collider is prey
            if (collider.gameObject.GetComponent<Animal>() != null && thisAnimal.PreyList.Contains(collider.gameObject.GetComponent<Animal>()))
            {
                collider.gameObject.GetComponent<Animal>().Stamina -= staminaDrain;
            }
        }
    }

    private void Idle()
    {
        thisAgent.Target = null;

        if (thisAnimal.Stamina <= staminaThreshold)
        {
            //rest
            Rest();
        }
        else
        {
            //explore
        }
    }

    private void Rest()
    {
        thisAnimal.Stamina += restRate;
    }

    private Animal GetTarget()
    {
        ClearDestroyedVisibleAgents();

        foreach (Animal animal in thisAnimal.VisibleAgentsList)
        {
            Animal prefab = animal.GetComponent<ParentPrefab>().Source.GetComponent<Animal>();
            if (thisAnimal.PreyList.Contains(prefab))
            {
                return animal;
            }
        }

        return null;
    }

    private void ClearDestroyedVisibleAgents()
    {
        for (int i = thisAnimal.VisibleAgentsList.Count - 1; i >= 0; i--)
        {
            if (thisAnimal.VisibleAgentsList[i] == null)
            {
                thisAnimal.VisibleAgentsList.RemoveAt(i);
            }
        }
    }
}
