using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Vector3 newPosition;
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
        newPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        Instantiate(agent, transform.position + newPosition, Quaternion.identity);
        i++;
    }
}