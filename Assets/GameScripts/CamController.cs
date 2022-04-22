using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public GameObject player; // stores a public variable reference to the player Gameobject.

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // calculate the offset value by getting the distance between the players position and the camera then storing it.
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
