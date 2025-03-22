using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("---- Bools ----")]
    [Header("Grounded Bools")]
    public bool isGrounded;
    public bool isCrouched;

    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float speedStep;
    [SerializeField] float sprintSpeed;
    private Vector3 movement;

    [Header("Jumping/Physics")]
    [SerializeField] float gravity;
    [SerializeField] float jumpForce;
    private Vector3 velocity;

    [Header("---- Components ----")]
    [SerializeField] CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        //isGrounded = controller.isGrounded;
        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        //float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        //Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        //moveDirection = moveDirection.normalized;

        //if (mouseScroll != 0)
        //{
        //    moveSpeed += mouseScroll * speedStep;
        //    moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);
        //}

        //float currentSpeed = mouseScroll * speedStep;
        //controller.Move(moveDirection *  currentSpeed * Time.deltaTime);

        //if (moveDirection != Vector3.zero)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        //}

        //velocity.y -= gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
        if (!isGrounded)
        {
            controller.Move(velocity * Time.deltaTime);
            velocity.y -= gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f;
        }
        isGrounded = controller.isGrounded;

        //Move Input
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        // Player Movement
        if (mouseScroll != 0)
        {
            moveSpeed += mouseScroll * speedStep;
            moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);
        }

        Vector3 move = new Vector3(movement.x, 0, movement.z);
        if (Input.GetButton("Jump"))
        {
            isCrouched = false;
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * moveSpeed * Time.deltaTime);
        }

        // Rotate to face direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = rot;
        }
    }
}
