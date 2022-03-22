using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : MonoBehaviour
{
    private AgentController thisAgent;
    private Animal thisAnimal;

    public List<INode> DecisionTree = new List<INode>();
    private Selector rootSelector = new Selector();
    private Sequence attackedSequence = new Sequence();
    private INode isBeingAttackedNode;
    private Selector runAwaySelector = new Selector();
    private INode hideNode = new Hide();
    private Sequence trapSequence = new Sequence();
    private INode isAbleToSetTrapNode = new AbleToSetTrap();
    private INode setTrapNode = new SetTrap();
    private INode runAwayNode = new RunAway();
    private Sequence checkVitalsSequence = new Sequence();
    private INode isHealthOrStaminaLowNode;
    private INode restNode;
    private INode exploreNode = new Explore();

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = gameObject.GetComponent<AgentController>();
        thisAnimal = gameObject.GetComponent<Animal>();

        isBeingAttackedNode = new BeingAttacked(thisAgent);
        isHealthOrStaminaLowNode = new HealthOrStaminaLow(thisAnimal);
        restNode = new Rest(thisAnimal);

        DecisionTree.Add(rootSelector);
        rootSelector.ChildNodes.Add(attackedSequence);
        rootSelector.ChildNodes.Add(checkVitalsSequence);
        rootSelector.ChildNodes.Add(exploreNode);
        attackedSequence.ChildNodes.Add(isBeingAttackedNode);
        attackedSequence.ChildNodes.Add(runAwaySelector);
        checkVitalsSequence.ChildNodes.Add(isHealthOrStaminaLowNode);
        checkVitalsSequence.ChildNodes.Add(restNode);
        runAwaySelector.ChildNodes.Add(hideNode);
        runAwaySelector.ChildNodes.Add(trapSequence);
        runAwaySelector.ChildNodes.Add(runAwayNode);
        trapSequence.ChildNodes.Add(isAbleToSetTrapNode);
        trapSequence.ChildNodes.Add(setTrapNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
