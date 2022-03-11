using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    private Rigidbody rb;
    private Animal thisAnimal;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        thisAnimal = gameObject.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveInput = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        rb.MovePosition(rb.position + (thisAnimal.StepSize * Time.deltaTime * moveInput.normalized));
        thisAnimal.Stamina -= thisAnimal.StaminaCost;
    }
}
