using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target;  // El jugador
    public float minDistance = 1.0f;  // Distancia mínima de la cámara al jugador
    public float maxDistance = 4.0f;  // Distancia máxima de la cámara al jugador
    public float smoothSpeed = 10f;   // Velocidad de ajuste de la cámara

    private Vector3 _defaultOffset;
    private float _currentDistance;

    void Start()
    {
        // Calcular el offset inicial entre el jugador y la cámara
        _defaultOffset = transform.position - target.position;
        _currentDistance = _defaultOffset.magnitude;
    }

    void LateUpdate()
    {
        // Dirección desde el jugador hacia la cámara
        Vector3 direction = _defaultOffset.normalized;
        RaycastHit hit;

        // Raycast desde el jugador en dirección hacia la cámara
        if (Physics.Raycast(target.position, direction, out hit, maxDistance))
        {
            // Si se detecta un objeto, reducir la distancia de la cámara
            _currentDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            // Si no se detecta nada, mantener la distancia máxima
            _currentDistance = maxDistance;
        }

        // Ajustar la posición de la cámara suavemente
        Vector3 desiredPosition = target.position + direction * _currentDistance;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}