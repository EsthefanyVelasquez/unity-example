using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CodigoSalud : MonoBehaviour
{
    public float Salud = 100; // Salud actual del jugador
    public float SaludMaxima = 100; // Salud máxima del jugador

    [Header("Interfaz")]
    public Image BarraSalud; // Referencia a la barra de salud UI
    public Text TextoSalud; // Referencia al texto de salud UI

    void Update()
    {
        ActualizarInterfaz(); // Actualiza la interfaz de usuario cada frame
    }

    public void RecibirDaño(float daño)
    {
        Salud -= daño; // Reduce la salud actual por la cantidad de daño
        if (Salud < 0) // Asegúrate de que la salud no sea negativa
        {
            Salud = 0; // Si la salud es menor que 0, establece a 0
        }
    }

    void ActualizarInterfaz()
    {
        // Verifica si las referencias están asignadas
        if (BarraSalud != null && TextoSalud != null)
        {
            BarraSalud.fillAmount = Salud / SaludMaxima; // Actualiza la barra de salud
            TextoSalud.text = "Salud: " + Salud.ToString("f0"); // Actualiza el texto de salud
        }
        else
        {
            // Mensaje de error en la consola si alguna referencia es null
            Debug.LogError("BarraSalud o TextoSalud no están asignados en el Inspector");
        }
    }
}

