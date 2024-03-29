using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : INode
{
    private Animal thisAnimal;
    private readonly float recoverySpeed = 0.4f;

    public Rest(Animal animal)
    {
        thisAnimal = animal;
    }

    public bool Run()
    {
        thisAnimal.Stamina += recoverySpeed;
        return true;
    }
}
