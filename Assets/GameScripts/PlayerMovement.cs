using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float StepSize;
    private Rigidbody rb;
    private Animal thisAnimal;
    [SerializeField]
    private float staminaCost;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        thisAnimal = gameObject.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + (StepSize * Time.deltaTime * moveInput.normalized));
        thisAnimal.Stamina -= 2;
    }
}
