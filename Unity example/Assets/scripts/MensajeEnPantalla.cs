using UnityEngine;
using TMPro;

public class MensajeEnPantallaTMP : MonoBehaviour
{
    public TextMeshProUGUI mensajeUI;  // Campo para el TextMeshPro donde aparecerá el mensaje
    public string mensaje = "Sugerencia: Presiona E para interactuar";  // Mensaje personalizado
    public string tagJugador = "Player"; // Tag del objeto del jugador

    private void Start()
    {
        // Oculta el mensaje al inicio
        if (mensajeUI != null)
        {
            mensajeUI.text = "";
        }
        else
        {
            Debug.LogWarning("No se ha asignado el campo 'mensajeUI'. Por favor, asigna un componente TextMeshProUGUI en el Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el collider, mostrar el mensaje
        if (other.CompareTag(tagJugador) && mensajeUI != null)
        {
            mensajeUI.text = mensaje;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del collider, ocultar el mensaje
        if (other.CompareTag(tagJugador) && mensajeUI != null)
        {
            mensajeUI.text = "";
        }
    }
}
