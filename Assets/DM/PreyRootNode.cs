using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyRootNode : MonoBehaviour
{
    private AgentController thisAgent;
    private Animal thisAnimal;
    private PreyWithTraps thisPreyWithTraps;

    private Selector rootSelector = new Selector();
    private Sequence attackedSequence = new Sequence();
    private INode isBeingAttackedNode;
    private Selector runAwaySelector = new Selector();
    private INode hideNode = new Hide();
    private Sequence trapSequence = new Sequence();
    private INode isAbleToSetTrapNode;
    private INode setTrapNode;
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
        thisPreyWithTraps = gameObject.GetComponent<PreyWithTraps>();

        isBeingAttackedNode = new BeingAttacked(thisAgent);
        isAbleToSetTrapNode = new AbleToSetTrap(thisPreyWithTraps);
        setTrapNode = new SetTrap(thisPreyWithTraps);
        isHealthOrStaminaLowNode = new HealthOrStaminaLow(thisAnimal);
        restNode = new Recover(thisAnimal);

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
        if (Time.frameCount % 2 == 0)
        {
            bool result = rootSelector.Run();
           // Debug.Log("test " + result + Time.frameCount);
        }
    }
}
