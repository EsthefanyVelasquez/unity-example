using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    [Range(0, 1)] public float lerpValue = 0.1f;
    public float sensibilidad = 5f;

    private float currentXRotation = 0f; // Rotación actual en el eje X (vertical)
    private float currentYRotation = 0f; // Rotación actual en el eje Y (horizontal)
    public float minXRotation = -40f;    // Límite de rotación hacia abajo
    public float maxXRotation = 80f;     // Límite de rotación hacia arriba

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

    // LateUpdate se llama después de todos los updates
    void LateUpdate()
    {
        if (target == null) return;

        // Rotación horizontal y vertical basada en la entrada del mouse
        currentYRotation += Input.GetAxis("Mouse X") * sensibilidad;
        currentXRotation -= Input.GetAxis("Mouse Y") * sensibilidad;

        // Limitar la rotación en el eje X (vertical)
        currentXRotation = Mathf.Clamp(currentXRotation, minXRotation, maxXRotation);

        // Aplicar la rotación a la cámara
        Quaternion rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Mover la cámara con Lerp para suavizar el movimiento
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpValue);

        // Hacer que la cámara mire al jugador
        transform.LookAt(target);
    }
}
