using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrStaminaLow : INode
{
    private Animal thisAnimal;
    private readonly float threshold = 30f;

    public HealthOrStaminaLow(Animal animal)
    {
        thisAnimal = animal;
    }

    public bool Run()
    {
        if (thisAnimal.Health < threshold || thisAnimal.Stamina < threshold)
        {
            return true;
        }

        return false;
    }
}
