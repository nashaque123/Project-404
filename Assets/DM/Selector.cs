using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : IComposite
{
    public List<INode> ChildNodes { get; set; }

    public bool Run()
    {
        foreach (INode child in ChildNodes)
        {
            if (child.Run())
            {
                return true;
            }
        }

        return false;
    }
}
