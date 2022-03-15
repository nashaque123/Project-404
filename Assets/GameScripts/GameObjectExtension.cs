using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension
{
    public static Transform GetParentFromCollision(Collider collider)
    {
        if (collider.transform.parent != null)
        {
            return collider.transform.parent;
        }
        else
        {
            return collider.transform;
        }
    }
}
