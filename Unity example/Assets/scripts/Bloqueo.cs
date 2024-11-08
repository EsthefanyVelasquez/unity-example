using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerColliderActivator : MonoBehaviour
{
    public Collider colliderToActivate;  // El segundo collider que queremos activar

    private void Start()
    {
        // Asegurarse de que el segundo collider esté desactivado al inicio
        if (colliderToActivate != null)
        {
            colliderToActivate.enabled = false;
        }

        // Suscribirse al evento de carga de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Activar el segundo collider al detectar al jugador
        if (other.CompareTag("Player") && colliderToActivate != null)
        {
            colliderToActivate.enabled = true;
            Debug.Log("Collider activado permanentemente.");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Desactivar el collider cuando se recargue la escena
        if (colliderToActivate != null)
        {
            colliderToActivate.enabled = false;
            Debug.Log("Collider reiniciado al cargar la escena.");
        }
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento para evitar errores
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

