using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrap : INode
{
    private PreyWithTraps thisAnimal;

    public SetTrap(PreyWithTraps preyWithTraps)
    {
        thisAnimal = preyWithTraps;
    }

    public bool Run()
    {
        //set trap
        thisAnimal.SetTrap();
        return true;
    }
}
