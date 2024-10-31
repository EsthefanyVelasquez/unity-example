using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject pauseMenu;
    public GameObject victoryMenu; // Nuevo: Panel para el mensaje de victoria
    private bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;
    }

    public void OpenSettings()
    {
        Debug.Log("Abrir Configuración");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Nuevo: Método para activar el menú de victoria
    public void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego al ganar
        Debug.Log("¡Has ganado!");
    }
}
