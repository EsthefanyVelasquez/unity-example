using UnityEngine;
using UnityEngine.UI;

public class MostrarImagenEnPantalla : MonoBehaviour
{
    public Image imagenUI1; // Primera imagen de la UI
    public Image imagenUI2; // Segunda imagen de la UI (opcional)
    public Image imagenUI3; // Tercera imagen de la UI (opcional)
    public string tagJugador = "Player"; // Tag del objeto del jugador

    private void Start()
    {
        // Ocultar todas las imágenes al inicio
        if (imagenUI1 != null) imagenUI1.enabled = false;
        if (imagenUI2 != null) imagenUI2.enabled = false;
        if (imagenUI3 != null) imagenUI3.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Mostrar las imágenes cuando el jugador entre en el collider
        if (other.CompareTag(tagJugador))
        {
            if (imagenUI1 != null) imagenUI1.enabled = true;
            if (imagenUI2 != null) imagenUI2.enabled = true;
            if (imagenUI3 != null) imagenUI3.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ocultar las imágenes cuando el jugador salga del collider
        if (other.CompareTag(tagJugador))
        {
            if (imagenUI1 != null) imagenUI1.enabled = false;
            if (imagenUI2 != null) imagenUI2.enabled = false;
            if (imagenUI3 != null) imagenUI3.enabled = false;
        }
    }
}
