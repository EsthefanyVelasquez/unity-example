using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public new Transform camera;
    public float speed = 4;
    public float gravity = -9.8f;
    public float rotationSpeed = 100f; // Velocidad de rotación del personaje
    public float jumpHeight = 2.0f;    // Altura del salto
    public float jumpForce = 8.0f;     // Fuerza del salto

    private float verticalVelocity;    // Velocidad vertical para salto y gravedad
    private bool isGrounded;           // Para verificar si está en el suelo

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal"); // Flechas izquierda/derecha
        float ver = Input.GetAxis("Vertical");   // Flechas adelante/atrás
        Vector3 movement = Vector3.zero;

        // Verificar si el personaje está en el suelo
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            verticalVelocity = 0; // Resetea la velocidad vertical al tocar el suelo

            // Si está en el suelo y presionamos la tecla de salto (barra espaciadora)
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce; // Aplicar la fuerza del salto
            }
        }
        else
        {
            // Aplicar la gravedad mientras no está en el suelo
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Movimiento de avance
        if (ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            movement = forward * ver * speed * Time.deltaTime;
        }

        // Aplicar la rotación
        if (hor != 0)
        {
            // Rotar el personaje en el eje Y (izquierda o derecha)
            transform.Rotate(0, hor * rotationSpeed * Time.deltaTime, 0);
        }

        // Aplicar la velocidad vertical (salto o caída)
        movement.y = verticalVelocity * Time.deltaTime;

        // Mover el personaje
        characterController.Move(movement);
    }
}

