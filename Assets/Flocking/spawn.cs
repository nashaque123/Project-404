using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private int i = 0;
    [SerializeField] private GameObject agent;

    // Start is called before the first frame update
    void Update()
    {
        if (i < 10)
        {
            spawnIn();
        }
    }

    private void spawnIn()
    {
        Instantiate(agent, transform.position, Quaternion.identity);
        i++;
    }
}
