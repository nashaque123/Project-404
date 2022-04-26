using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : INode
{
    private Animal thisAnimal;
    private AgentController agent;

    public Hide(Animal animal, AgentController _agent)
    {
        thisAnimal = animal;
        agent = _agent;
    }

    public bool Run()
    {
        agent.Target = null;

        //hide
        if (CheckForHidingSpot())
        {
            agent.Target = thisAnimal.VisibleHidingSpotList[0];

            if (Vector3.Distance(agent.Target.transform.position, thisAnimal.transform.position) <= 5f)
            {
                EnterHidingSpot();
                return true;
            }
        }

        thisAnimal.gameObject.GetComponent<MeshRenderer>().enabled = true;
        return false;
    }

    private void EnterHidingSpot()
    {
        thisAnimal.gameObject.GetComponent<MeshRenderer>().enabled = false;
        thisAnimal.Stamina += 0.15f;
        thisAnimal.Health += 0.15f;
    }

    private bool CheckForHidingSpot()
    {
        return thisAnimal.VisibleHidingSpotList.Count > 0;
    }

}
