using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<Waypoints> neighbours;

    public Waypoints previous
    {
        get;
        set;
    }

    public Waypoints distance
    {
        get;
        set;
    }

    private void OnDrawGizmos()
    {
        if (neighbours == null)
            return;
        Gizmos.color = new Color(50f, 0f, 40f);
        foreach (var neighbour in neighbours)
        {
            if (neighbour != null)
                Gizmos.DrawLine(transform.position, neighbour.transform.position);
        }
    }
}
