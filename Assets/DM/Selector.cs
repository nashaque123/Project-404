using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public override bool Execute()
    {
        foreach (ITaskNode child in ChildNodes)
        {
            if (child.Action())
            {
                return true;
            }
        }

        return false;
    }
}
