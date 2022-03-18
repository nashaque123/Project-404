using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    public override bool Execute()
    {
        foreach (ITaskNode child in ChildNodes)
        {
            if (!child.Action())
            {
                return false;
            }
        }

        return true;
    }
}
