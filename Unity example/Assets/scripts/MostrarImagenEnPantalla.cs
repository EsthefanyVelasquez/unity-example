using UnityEngine;
using UnityEngine.UI;

public class MostrarImagenEnPantalla : MonoBehaviour
{
    public Image imagenUI;  // Referencia al componente Image de la UI
    public string tagJugador = "Player"; // Tag del objeto del jugador

    private void Start()
    {
        // Oculta la imagen al inicio
        if (imagenUI != null)
        {
            imagenUI.enabled = false;
        }
        else
        {
            Debug.LogWarning("No se ha asignado el campo 'imagenUI'. Por favor, asigna un componente Image en el Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el collider, mostrar la imagen
        if (other.CompareTag(tagJugador) && imagenUI != null)
        {
            imagenUI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del collider, ocultar la imagen
        if (other.CompareTag(tagJugador) && imagenUI != null)
        {
            imagenUI.enabled = false;
        }
    }
}

