using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bounciness = 0.8f;  // Coeficiente de restituci�n (elasticidad)
    [SerializeField] private float gravity = 9.8f;      // Gravedad
    [SerializeField] private float damping = 0.9f;      // Factor de amortiguaci�n (disminuye la velocidad de rebote)
    private Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Desactivamos la gravedad de Rigidbody para manejarla manualmente
    }

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        // Aplica la gravedad en el eje Y
        velocity.y -= gravity * Time.deltaTime;
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto toca el suelo o cualquier superficie
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Rebote b�sico: invertir la velocidad y aplicar el coeficiente de restituci�n
            velocity.y = -velocity.y * bounciness;

            // Aplica amortiguaci�n (reduce la velocidad de rebote en cada colisi�n)
            velocity *= damping;

            // Evitar rebotes continuos cuando la velocidad es muy baja
            if (Mathf.Abs(velocity.y) < 0.1f)
            {
                velocity = Vector3.zero;  // Detiene el objeto por completo
            }
        }
    }
}
