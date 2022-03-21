using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingAttacked : MonoBehaviour, INode
{
    private AgentController thisAgent;

    // Start is called before the first frame update
    private void Start()
    {
        thisAgent = gameObject.GetComponent<AgentController>();
    }

    public bool Run()
    {
        return thisAgent.EnemyAgentWithinRange();
    }
}
