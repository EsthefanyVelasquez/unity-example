using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciargameover : MonoBehaviour
{
   public void Reiniciar()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
