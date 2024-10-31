using UnityEngine;
using UnityEngine.UI;

public class Meta : MonoBehaviour
{
    public GameObject canvas1; // Asegúrate de asignar esto en el Inspector
    public Text txtMeta; // Asegúrate de asignar el Text en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            canvas1.SetActive(true); // Activa el canvas de victoria
            txtMeta.text = "¡HAS GANADO!"; // Muestra el mensaje de victoria
            Time.timeScale = 0f; // Pausa el juego
        }
    }
}
