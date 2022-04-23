using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // calculate the offset value by getting the distance between the players position and the camera then storing it.
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 newPos = playerTransform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
