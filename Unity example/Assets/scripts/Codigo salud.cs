using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CodigoSalud : MonoBehaviour
{
    public float Salud = 100; // Salud actual del jugador
    public float SaludMaxima = 100; // Salud máxima del jugador

    [Header("Interfaz")]
    public Image BarraSalud; // Referencia a la barra de salud UI (Image o Slider)
    public Text TextoSalud; // Referencia al texto de salud UI

    public GameObject Muerto; // Prefab o GameObject a instanciar al morir
    public GameObject GameOverUI; // Prefab de la interfaz de Game Over

    private void Start()
    {
        // Asegura que la barra de salud y el texto estén inicializados correctamente
        if (BarraSalud != null)
        {
            BarraSalud.fillAmount = Salud / SaludMaxima; // Inicializa la barra con el valor inicial de salud
        }

        if (TextoSalud != null)
        {
            TextoSalud.text = "Salud: " + Salud.ToString("f0"); // Inicializa el texto de salud
        }
    }

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
            // Actualiza la barra de salud
            BarraSalud.fillAmount = Salud / SaludMaxima;

            // Actualiza el texto de salud
            TextoSalud.text = "Salud: " + Salud.ToString("f0");
        }
        else
        {
            // Mensaje de error en la consola si alguna referencia es null
            if (BarraSalud == null)
            {
                Debug.LogError("BarraSalud no está asignada en el Inspector");
            }

            if (TextoSalud == null)
            {
                Debug.LogError("TextoSalud no está asignado en el Inspector");
            }
        }
    }
}
