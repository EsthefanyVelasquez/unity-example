using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public new Transform camera;
    public float speed = 4;
    public float brakeSpeed = 1.5f;  // Nueva variable para la velocidad de frenado
    public float gravity = -9.8f;
    public float rotationSpeed = 100f;
    public float jumpHeight = 2.0f;
    public float jumpForce = 8.0f;

    private float verticalVelocity;
    private bool isGrounded;
    private float currentSpeed;  // Velocidad actual ajustada según si está frenando

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeed = speed;  // Inicialmente, la velocidad es la velocidad normal
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;

        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            verticalVelocity = 0;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Cambiar velocidad según si está frenando
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Frenar con S o flecha hacia abajo
        {
            currentSpeed = brakeSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        if (ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            movement = forward * ver * currentSpeed * Time.deltaTime;  // Usar currentSpeed para permitir frenado
        }

        if (hor != 0)
        {
            transform.Rotate(0, hor * rotationSpeed * Time.deltaTime, 0);
        }

        movement.y = verticalVelocity * Time.deltaTime;

        characterController.Move(movement);
    }
}


