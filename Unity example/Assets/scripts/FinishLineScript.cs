using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class FinishLineScript : MonoBehaviour
{
    public TMP_Text finishText;        // Texto con TextMesh Pro que aparecer� al llegar a la meta
    public Image finishImage;          // Imagen que aparecer� (opcional)

    private bool playerReachedFinish = false;
    private float timer = 0f;
    private float waitTime = 2f;       // Tiempo de espera en segundos

    private void Start()
    {
        // Aseg�rate de que el texto y la imagen est�n inicialmente ocultos
        if (finishText != null)
        {
            finishText.gameObject.SetActive(false); // Oculta el texto al inicio
        }
        if (finishImage != null)
        {
            finishImage.enabled = false; // Desactiva la imagen al inicio
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica que sea el jugador
        {
            playerReachedFinish = true;

            // Activa el texto y la imagen cuando el jugador llega a la meta
            if (finishText != null)
            {
                finishText.gameObject.SetActive(true);
                finishText.text = "�Haz Llegado a la UMNG!";
            }
            if (finishImage != null)
            {
                finishImage.enabled = true; // Activa la imagen si est� definida
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica que sea el jugador
        {
            playerReachedFinish = false;
            timer = 0f; // Reinicia el temporizador al salir del �rea de la meta

            // Desactiva el texto y la imagen cuando el jugador salga del �rea
            if (finishText != null)
            {
                finishText.gameObject.SetActive(false);
            }
            if (finishImage != null)
            {
                finishImage.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (playerReachedFinish)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                // Cambia al siguiente nivel (nivel 2 con �ndice 2)
                SceneManager.LoadScene(2);
            }
        }
    }
}
