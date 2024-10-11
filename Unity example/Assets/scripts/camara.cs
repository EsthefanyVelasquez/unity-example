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

        // Aplicar gravedad
        movement.y += gravity * Time.deltaTime;

        // Mover el personaje
        characterController.Move(movement);
    }
}

