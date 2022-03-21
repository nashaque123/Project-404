using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComposite : INode
{
    public List<INode> ChildNodes
    {
        get;
        set;
    }
}
