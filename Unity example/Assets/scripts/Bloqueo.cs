using UnityEngine;

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
}
