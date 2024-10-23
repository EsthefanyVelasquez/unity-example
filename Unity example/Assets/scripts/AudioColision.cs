using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioColision : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

}
