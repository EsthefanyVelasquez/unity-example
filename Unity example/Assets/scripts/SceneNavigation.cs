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

    // Método para mostrar el panel de créditos
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    // Método para ocultar el panel de créditos
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    // Método para mostrar el panel de configuración
    public void ShowConfigPanel()
    {
        configPanel.SetActive(true);
    }

    // Método para ocultar el panel de configuración
    public void HideConfigPanel()
    {
        configPanel.SetActive(false);
    }


    public SceneNavigation(GameObject confirmExitPanel)
    {
        this.confirmExitPanel = confirmExitPanel;
    }

    // Método para mostrar la ventana emergente de confirmación
    public void MostrarVentanaEmergente()
    {
        confirmExitPanel.SetActive(true);
    }

    // Método para salir del juego
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Salir del juego"); // Esto solo se verá en el editor.
    }

    // Método para cancelar la salida
    public void CancelarSalida()
    {
        confirmExitPanel.SetActive(false);
    }

    // Método para cambiar a Pantalla 2
    public void IrAPantalla2()
    {
        SceneManager.LoadScene("Pantalla2"); 
    }

    // Método para volver a Pantalla 1
    public void VolverAPantalla1()
    {
        SceneManager.LoadScene("Pantalla1");
    }

    // Método para volver a Pantalla 1
    public void IrAPantalla3()
    {
        SceneManager.LoadScene("Pantalla3");
    }

    // Método para volver a Pantalla 2
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
