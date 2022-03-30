using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{

    public float moveSpeed = 30f;
    public float rotateSpeed = 50f;

    private bool isRoaming = false;
    private bool isRotatingL = false;
    private bool isRotatingR = false;
    private bool isWalking = false;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRoaming == false)
        {
            StartCoroutine(Roam());

            if (isRotatingR == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);
            }

            if (isRotatingL == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotateSpeed);
            }
            if (isWalking == true)
            {
                rb.AddForce(transform.forward * moveSpeed);
            }
        }

        IEnumerator Roam()
        {
            int rotateTime = Random.Range(1, 5);
            int rotateWait = Random.Range(1, 2);
            int rotateDir = Random.Range(1, 2);
            int walkingWait = Random.Range(1, 4);
            int walkingTime = Random.Range(1, 4);

            isRoaming = true;

            yield return new WaitForSeconds(walkingWait);

            isWalking = true;

            yield return new WaitForSeconds(walkingTime);

            isWalking = false;

            yield return new WaitForSeconds(rotateWait);

            if (rotateDir == 1)
            {
                isRotatingL = true;
                yield return new WaitForSeconds(rotateTime);
                isRotatingL = false;
            }


            if (rotateDir == 2)
            {
                isRotatingR = true;
                yield return new WaitForSeconds(rotateTime);
                isRotatingR = false;
            }

            isRoaming = false;
        } 
    }
}
