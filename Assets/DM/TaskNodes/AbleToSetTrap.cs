using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleToSetTrap : INode
{
    private PreyWithTraps thisAnimal;

    public AbleToSetTrap(PreyWithTraps preyWithTraps)
    {
        thisAnimal = preyWithTraps;
    }

    public bool Run()
    {
        //return true if trap timer is complete
        return thisAnimal.CanSetTrap;
    }
}
