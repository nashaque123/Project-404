using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaLow : INode
{
    private Animal thisAnimal;
    private readonly float threshold = 20f;

    public StaminaLow(Animal animal)
    {
        thisAnimal = animal;
    }

    public bool Run()
    {
        if (thisAnimal.Stamina < threshold)
        {
            return true;
        }

        return false;
    }
}
