using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    [Range(0, 1)] public float lerpValue = 0.1f;
    public float sensibilidad = 5f;

    private float currentXRotation = 0f; // Rotaci�n actual en el eje X (vertical)
    private float currentYRotation = 0f; // Rotaci�n actual en el eje Y (horizontal)
    public float minXRotation = -40f;    // L�mite de rotaci�n hacia abajo
    public float maxXRotation = 80f;     // L�mite de rotaci�n hacia arriba

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                target = playerObject.transform;
            }
            else
            {
                Debug.LogError("No se pudo encontrar un objeto con la etiqueta 'Player'.");
            }
        }
    }

    // LateUpdate se llama despu�s de todos los updates
    void LateUpdate()
    {
        if (target == null) return;

        // Rotaci�n horizontal y vertical basada en la entrada del mouse
        currentYRotation += Input.GetAxis("Mouse X") * sensibilidad;
        currentXRotation -= Input.GetAxis("Mouse Y") * sensibilidad;

        // Limitar la rotaci�n en el eje X (vertical)
        currentXRotation = Mathf.Clamp(currentXRotation, minXRotation, maxXRotation);

        // Aplicar la rotaci�n a la c�mara
        Quaternion rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Mover la c�mara con Lerp para suavizar el movimiento
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpValue);

        // Hacer que la c�mara mire al jugador
        transform.LookAt(target);
    }
}
