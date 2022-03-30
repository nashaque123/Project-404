using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorRootNode : MonoBehaviour
{
    private Animal thisAnimal;

    private Selector rootSelector = new Selector();
    private Sequence huntingSequence = new Sequence();
    private INode isPreyVisibleNode;
    private Selector attackSelector = new Selector();
    private Sequence nearPreySequence = new Sequence();
    private INode isPreyWithinRangeNode;
    private INode attackNode;
    private INode chaseNode;
    private INode growlNode;
    private Sequence checkStaminaSequence = new Sequence();
    private INode isStaminaLowNode;
    private INode restNode;
    private INode exploreNode = new Explore();

    // Start is called before the first frame update
    void Start()
    {
        thisAnimal = gameObject.GetComponent<Animal>();

        growlNode = new Growl(thisAnimal);
        isStaminaLowNode = new StaminaLow(thisAnimal);
        restNode = new Rest(thisAnimal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
