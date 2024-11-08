using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Necesario si usas TextMeshPro para mostrar el temporizador en pantalla

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 180f;  // Tiempo inicial en segundos (3 minutos)
    public TMP_Text timerText;          // Referencia al texto para mostrar el temporizador (TextMeshPro)

    private bool timerIsRunning = false;

    public GameObject Muerto; // Prefab o GameObject a instanciar al morir
    public GameObject GameOverUI; // Prefab de la interfaz de Game Over

    private void Start()
    {
        // Iniciar el temporizador cuando comience el nivel
        timerIsRunning = true;

    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                // El temporizador ha terminado
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        // Formato de minutos y segundos
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Actualizar el texto del temporizador en pantalla
        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void GameOver()
    {
        // Cargar la pantalla de muerte al finalizar el tiempo
        Time.timeScale = 1f;  // Restablece la escala de tiempo

        if (Muerto != null)
        {
            Instantiate(Muerto, transform.position, transform.rotation); // Instancia el prefab de muerte
        }

        if (GameOverUI != null)
        {
            Instantiate(GameOverUI, Vector3.zero, Quaternion.identity); // Instancia la interfaz de Game Over en el centro de la pantalla
        }
       
    }
}
