using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
