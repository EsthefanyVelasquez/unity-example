using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDaño : MonoBehaviour
{
   public float CantidadDaño;

   private void OnTriggerEnter(Collider other)
   {
       // Elimina el punto y coma aquí
       if (other.CompareTag("Player") && other.GetComponent<CodigoSalud>())
       {
           // Ahora el código funcionará correctamente
           other.GetComponent<CodigoSalud>().RecibirDaño(CantidadDaño);
       }
   }
}
