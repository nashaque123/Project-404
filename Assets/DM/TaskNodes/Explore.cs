using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : INode
{
    Rigidbody rb;
    Animal animal;

    public Explore(Rigidbody _rb, Animal _animal)
    {
        rb = _rb;
        animal = _animal;
    }

    public bool Run()
    {
        //walk around
        //TODO: replace with flocking
        Vector3 moveInput = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        rb.MovePosition(rb.position + (animal.StepSize * Time.deltaTime * moveInput.normalized));
        animal.Stamina -= animal.StaminaCost;
        return true;
    }
}
