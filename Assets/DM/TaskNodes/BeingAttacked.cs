using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingAttacked : INode
{
    private AgentController thisAgent;

    public BeingAttacked(AgentController agent)
    {
        thisAgent = agent;
    }

    public bool Run()
    {
        //return thisAgent.EnemyAgentWithinRange();
        return false;
    }
}
