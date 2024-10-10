using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCENA : MonoBehaviour
{
    private float tiempo = 0f; // Inicializa la variable

    // Detecta cuando el jugador entra en colisión con el objeto
    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Player")) {
            Debug.Log("Jugador Entró");
        }
    }

    // Detecta cuando el jugador sigue en colisión con el objeto
    private void OnCollisionStay(Collision other) {
        if (other.collider.CompareTag("Player")) {
            tiempo += Time.deltaTime; // Suma el tiempo que el jugador permanece en colisión
            Debug.Log("Jugador en choque");
        }
    }

    // Detecta cuando el jugador sale de la colisión
    private void OnCollisionExit(Collision other) {
        if (other.collider.CompareTag("Player")) {
            Debug.Log("Jugador Salió después de: " + tiempo + " segundos en colisión");
            tiempo = 0; // Reinicia el tiempo una vez que el jugador sale
        }
    }
}
