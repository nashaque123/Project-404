using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growl : INode
{
    private Animal thisAnimal;
    private float growlRange = 10f;
    private float staminaDrain = 2f;

    public Growl(Animal animal)
    {
        thisAnimal = animal;
    }

    public bool Run()
    {
        Collider[] objectsWithinRange = Physics.OverlapSphere(thisAnimal.transform.position, growlRange);
        foreach (Collider collider in objectsWithinRange)
        {
            //check if collider is prey
            if (collider.gameObject.GetComponent<Animal>() != null && thisAnimal.PreyList.Contains(collider.gameObject.GetComponent<ParentPrefab>().Source.GetComponent<Animal>()))
            {
                collider.gameObject.GetComponent<Animal>().Stamina -= staminaDrain;
            }
        }

        return true;
    }
}
