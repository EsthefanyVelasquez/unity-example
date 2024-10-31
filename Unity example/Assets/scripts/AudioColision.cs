using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioColision : MonoBehaviour
{
    private AudioSource audioSource1;
    private AudioSource audioSource2;

    void Start()
    {
        // Obtener todos los AudioSource del objeto
        AudioSource[] audioSources = GetComponents<AudioSource>();

        if (audioSources.Length >= 1)
        {
            audioSource1 = audioSources[0]; // Primer AudioSource
        }

        if (audioSources.Length >= 2)
        {
            audioSource2 = audioSources[1]; // Segundo AudioSource, si existe
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Reproducir el primer audio si está asignado
            if (audioSource1 != null && !audioSource1.isPlaying)
            {
                audioSource1.Play();
            }

            // Reproducir el segundo audio si está asignado
            if (audioSource2 != null && !audioSource2.isPlaying)
            {
                audioSource2.Play();
            }
        }
    }
}