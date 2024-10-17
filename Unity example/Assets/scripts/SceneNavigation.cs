using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Referencia a la ventana emergente
    public GameObject confirmExitPanel;
    public GameObject configPanel;
    public GameObject creditsPanel;

    // M�todo para mostrar el panel de cr�ditos
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    // M�todo para ocultar el panel de cr�ditos
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    // M�todo para mostrar el panel de configuraci�n
    public void ShowConfigPanel()
    {
        configPanel.SetActive(true);
    }

    // M�todo para ocultar el panel de configuraci�n
    public void HideConfigPanel()
    {
        configPanel.SetActive(false);
    }


    public SceneNavigation(GameObject confirmExitPanel)
    {
        this.confirmExitPanel = confirmExitPanel;
    }

    // M�todo para mostrar la ventana emergente de confirmaci�n
    public void MostrarVentanaEmergente()
    {
        confirmExitPanel.SetActive(true);
    }

    // M�todo para salir del juego
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Salir del juego"); // Esto solo se ver� en el editor.
    }

    // M�todo para cancelar la salida
    public void CancelarSalida()
    {
        confirmExitPanel.SetActive(false);
    }

    // M�todo para cambiar a Pantalla 2
    public void IrAPantalla2()
    {
        SceneManager.LoadScene("Pantalla2"); 
    }

    // M�todo para volver a Pantalla 1
    public void VolverAPantalla1()
    {
        SceneManager.LoadScene("Pantalla1");
    }

    // M�todo para volver a Pantalla 1
    public void IrAPantalla3()
    {
        SceneManager.LoadScene("Pantalla3");
    }

    // M�todo para volver a Pantalla 2
    public void VolverAPantalla2()
    {
        SceneManager.LoadScene("Pantalla2");
    }

    public void IrAPantalla4()
    {
        SceneManager.LoadScene("Pantalla4");
    }

    public void VolverAPantalla3()
    {
        SceneManager.LoadScene("Pantalla3");
    }

    public void IrAPantalla5()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
