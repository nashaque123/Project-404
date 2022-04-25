using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : INode
{
    private Animal thisAnimal;

    public Hide(Animal animal)
    {
        thisAnimal = animal;
    }

    public bool Run()
    {
        //hide
        if (CheckForHidingSpot())
        {
            EnterHidingSpot();
            return true;
        }
        return false;
    }

    private void EnterHidingSpot()
    {
        thisAnimal.gameObject.GetComponent<MeshRenderer>().enabled = false;
        thisAnimal.Stamina += 0.15f;
        thisAnimal.Health += 0.15f;
    }

    private bool CheckForHidingSpot()
    {
        return thisAnimal.VisibleHidingSpotList.Count > 0;
    }

}
