using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidbody : MonoBehaviour
{
    public float pushPower = 2.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Obtener el Rigidbody del objeto con el que colisiona el jugador
        Rigidbody body = hit.collider.attachedRigidbody;

        // Si no hay Rigidbody o el objeto es kinemático, salir
        if (body == null || body.isKinematic)
        {
            return;
        }

        // Asegurarse de que el cuerpo con el que chocamos no sea demasiado ligero
        float targetMass = Mathf.Max(body.mass, 1.0f);  // Evitar dividir por valores demasiado pequeños

        // Solo empujar en el eje X y Z (no empujar hacia arriba)
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Aplicar la velocidad al objeto empujado según su masa
        body.velocity = pushDir * pushPower / targetMass;
    }
}