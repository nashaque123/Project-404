using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animal thisAnimal;
    private Vector3 moveInput;

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
            if (thisAnimal.CanAttack)
            {
                List<Animal> enemiesWithinRange = GetAllEnemiesWithinRange();
                foreach (Animal enemy in enemiesWithinRange)
                {
                    StartCoroutine(thisAnimal.Attack(enemy));
                }
            }
        }
    }

    private List<Animal> GetAllEnemiesWithinRange()
    {
        List<Animal> enemiesWithinRange = new List<Animal>();
        Collider[] objectsWithinRange = Physics.OverlapSphere(thisAnimal.transform.position, thisAnimal.AttackRange);
        foreach (Collider collider in objectsWithinRange)
        {
            //check if collider is prey
            if (collider.gameObject.GetComponent<Animal>() != null && 
                (thisAnimal.PredatorList.Contains(collider.gameObject.GetComponent<Animal>()) || thisAnimal.PreyList.Contains(collider.gameObject.GetComponent<Animal>())))
            {
                enemiesWithinRange.Add(collider.gameObject.GetComponent<Animal>());
            }
        }

        return enemiesWithinRange;
    }
}
