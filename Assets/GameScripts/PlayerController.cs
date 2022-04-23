using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animal thisAnimal;
    private Vector3 moveInput;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        thisAnimal = gameObject.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (moveInput.magnitude > 0)
        {
            rb.MovePosition(rb.position + (thisAnimal.StepSize * Time.deltaTime * moveInput.normalized));
            thisAnimal.Stamina -= thisAnimal.StaminaCost;
        }
        else
        {
            thisAnimal.Stamina += 0.1f;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0"))
        {
            //attack
        }

        if (moveInput != Vector3.zero) //(Sara edit)
        {
            Quaternion toRoatation = Quaternion.LookRotation(moveInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoatation, rotationSpeed * Time.deltaTime);
        }
    }
}
