using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody rb;
    private Animal thisAnimal;
    //private Vector3 moveInput;
    public float rotationSpeed;
    [SerializeField] Transform playerCam = null;
    [SerializeField] float LookSensitivity = 2.5f;
    [SerializeField] float moveSpeed = 5.0f;
    CharacterController controller = null;

    float cameraPitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
        thisAnimal = gameObject.GetComponent<Animal>();

        controller =GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //if (moveInput.magnitude > 0)
        //{
        //    rb.MovePosition(rb.position + (thisAnimal.StepSize * Time.deltaTime * moveInput.normalized));
        //    thisAnimal.Stamina -= thisAnimal.StaminaCost;
        //}
        //else
        //{
        //    thisAnimal.Stamina += 0.1f;
        //}

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0"))
        {
            //attack
        }

        //if (moveInput != Vector3.zero) //(Sara edit)
        //{
        //    Quaternion toRoatation = Quaternion.LookRotation(moveInput, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoatation, rotationSpeed * Time.deltaTime);
        //}

        UpdateRightStickView();
        UpdateMovement();
    }

    void UpdateRightStickView()
    {
        Vector2 rightStickDelta = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));

        cameraPitch -= rightStickDelta.y * LookSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCam.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * rightStickDelta.x * LookSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();

        Vector3 velocity = (transform.forward * moveInput.y + transform.right * moveInput.x) * moveSpeed;
        controller.Move(velocity * Time.deltaTime);
    }
}
