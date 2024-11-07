using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MetaFinalScript : MonoBehaviour
{
    public GameObject mensajePanel;    // Panel que contiene el mensaje y la imagen
    public TMP_Text finalText;         // Texto con TextMesh Pro que aparecerá al llegar a la meta
    public Image finalImage;           // Imagen opcional que aparecerá
    public float tiempoEspera = 3f;    // Tiempo de espera en segundos antes de volver al menú

    private bool jugadorEnMeta = false;
    private float contador = 0f;

    private void Start()
    {
        // Asegúrate de que el panel de mensaje y la imagen estén desactivados inicialmente
        if (mensajePanel != null)
        {
            mensajePanel.SetActive(false);
        }
        if (finalImage != null)
        {
            finalImage.enabled = false;
        }
        if (finalText != null)
        {
            finalText.text = ""; // Oculta el texto inicialmente
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador llegó a la meta
        {
            jugadorEnMeta = true;

            // Activa el panel de mensaje y configura el texto e imagen
            if (mensajePanel != null)
            {
                mensajePanel.SetActive(true);
            }
            if (finalText != null)
            {
                finalText.text = "¡Felicidades! Has completado el juego!";
            }
            if (finalImage != null)
            {
                finalImage.enabled = true; // Activa la imagen
            }
        }
    }

    private void Update()
    {
        if (jugadorEnMeta)
        {
            // Incrementa el contador de tiempo mientras el jugador está en la meta
            contador += Time.deltaTime;
            if (contador >= tiempoEspera)
            {
                // Carga la escena del menú principal después del tiempo de espera
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador sale de la meta
        {
            jugadorEnMeta = false;
            contador = 0f; // Reinicia el contador

            // Oculta el panel de mensaje, texto e imagen al salir de la meta
            if (mensajePanel != null)
            {
                mensajePanel.SetActive(false);
            }
            if (finalImage != null)
            {
                finalImage.enabled = false;
            }
            if (finalText != null)
            {
                finalText.text = "";
            }
        }
    }
}
