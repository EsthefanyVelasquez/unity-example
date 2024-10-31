using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        // Este comando solo funciona en el ejecutable
        Application.Quit();

        // Si estás probando dentro del editor de Unity, usa esto para ver que el botón funciona:
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}