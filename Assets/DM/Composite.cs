using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : MonoBehaviour
{
    public List<ITaskNode> ChildNodes = new List<ITaskNode>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (ITaskNode child in ChildNodes)
        {
            child.Parent = this;
        }
    }

    public abstract bool Execute();
}
