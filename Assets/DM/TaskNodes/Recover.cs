using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : INode
{
    private Animal thisAnimal;
    private readonly float recoverySpeed = 0.5f;

    public Recover(Animal animal)
    {
        thisAnimal = animal;
    }

    public bool Run()
    {
        thisAnimal.Health += recoverySpeed;
        thisAnimal.Stamina += recoverySpeed;
        return true;
    }
}
