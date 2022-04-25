using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingAttacked : INode
{
    private AgentController thisAgent;
    private Animal thisAnimal;

    public BeingAttacked(AgentController agent, Animal animal)
    {
        thisAgent = agent;
        thisAnimal = animal;
    }

    public bool Run()
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
}
