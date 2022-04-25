using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPrefab : MonoBehaviour
{
    private GameObject source;

    public GameObject Source
    {
        get
        {
            return source;
        }

        set
        {
            source = value;
        }
    }
}
