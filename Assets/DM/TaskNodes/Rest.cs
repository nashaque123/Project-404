using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : MonoBehaviour, INode
{
    private Animal thisAnimal;
    private readonly float recoverySpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();
    }

    public bool Run()
    {
        thisAnimal.Health += recoverySpeed;
        thisAnimal.Stamina += recoverySpeed;
        return true;
    }
}
