using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject instructionPanel;  // El panel que contiene las instrucciones
    public GameObject player;  // El objeto jugador que se activará al iniciar
    private bool gameStarted = false;

    void Start()
    {
        // Al iniciar, mostrar las instrucciones y desactivar al jugador
        instructionPanel.SetActive(true);
        player.SetActive(false);
    }

    // Función para iniciar el juego
    public void StartGame()
    {
        // Ocultar las instrucciones y activar al jugador
        instructionPanel.SetActive(false);
        player.SetActive(true);
        gameStarted = true;
    }

    void Update()
    {
        // También puedes permitir que el jugador comience el juego con una tecla, por ejemplo, la barra espaciadora
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
}
