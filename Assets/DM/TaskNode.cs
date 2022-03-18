using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITaskNode
{
    public Composite Parent
    {
        get;
        set;
    }

    public bool Action();
}
