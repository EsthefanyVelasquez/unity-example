using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraColisionConRigidbody : MonoBehaviour
{
    public Transform objetivo;  // El objetivo a seguir, por ejemplo, el jugador
    public float distanciaMaxima = 5f;  // Distancia máxima que la cámara puede estar del objetivo
    public float suavidad = 10f;  // Suavidad con la que la cámara se mueve

    private Vector3 direccion;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Normaliza la dirección de la cámara
        direccion = transform.localPosition.normalized;
    }

    void Update()
    {
        Vector3 posicionDeseada = objetivo.TransformPoint(direccion * distanciaMaxima);

        RaycastHit hit;
        if (Physics.Raycast(objetivo.position, direccion, out hit, distanciaMaxima))
        {
            // Si detecta colisión, ajusta la distancia
            Vector3 nuevaPosicion = hit.point;
            rb.MovePosition(Vector3.Lerp(transform.position, nuevaPosicion, Time.deltaTime * suavidad));
        }
        else
        {
            // Si no hay colisión, mueve la cámara a la posición deseada
            rb.MovePosition(Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * suavidad));
        }
    }
}

