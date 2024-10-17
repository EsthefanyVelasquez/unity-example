using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meta : MonoBehaviour
{
    public GameObject Canvas1;
    public Text txtmeta;
    private void OnTriggerEnter(Collider Player)
    {
        if(Player.name == "Trigger")
        {
            Canvas1.SetActive(true);
            txtmeta.text = "HAS GANADO";

        }
    }
}
