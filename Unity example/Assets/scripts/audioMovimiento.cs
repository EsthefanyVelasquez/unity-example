using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMovimiento : MonoBehaviour
{
    public AudioSource bikeAudioSource;           // El componente AudioSource que reproduce el sonido
    public CharacterController characterController;  // El CharacterController del jugador
    public float movementThreshold = 0.1f;        // Umbral mínimo para considerar que la bicicleta se está moviendo

    void Update()
    {
        // Verificar la magnitud del movimiento del CharacterController
        if (characterController.velocity.magnitude > movementThreshold)
        {
            if (!bikeAudioSource.isPlaying)
            {
                bikeAudioSource.Play();  // Reproduce el sonido si no se está reproduciendo y el personaje se está moviendo
            }
        }
        else
        {
            if (bikeAudioSource.isPlaying)
            {
                bikeAudioSource.Stop();  // Detén el sonido si el personaje está detenido
            }
        }
    }
}
