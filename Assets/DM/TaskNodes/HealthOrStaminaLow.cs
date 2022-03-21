using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrStaminaLow : MonoBehaviour, INode
{
    private Animal thisAnimal;
    private readonly float threshold = 30f;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
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
