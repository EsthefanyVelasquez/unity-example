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

    public GameObject Muerto; // Prefab o GameObject a instanciar al morir
    public GameObject GameOverUI; // Prefab de la interfaz de Game Over

    void Update()
    {
        ActualizarInterfaz(); // Actualiza la interfaz de usuario cada frame
    }

    public void RecibirDaño(float daño)
    {
        Salud -= daño; // Reduce la salud actual por la cantidad de daño
        if (Salud <= 0) // Asegúrate de que la salud no sea negativa
        {
            Salud = 0; // Asegúrate de que la salud no sea menor que 0

            if (Muerto != null)
            {
                Instantiate(Muerto, transform.position, transform.rotation); // Instancia el prefab de muerte
            }

            if (GameOverUI != null)
            {
                Instantiate(GameOverUI, Vector3.zero, Quaternion.identity); // Instancia la interfaz de Game Over en el centro de la pantalla
            }

            Destroy(gameObject); // Destruye el objeto actual (este GameObject)
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
