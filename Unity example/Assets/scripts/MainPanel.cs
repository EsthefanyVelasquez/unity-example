using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
 [Header("options")]
 public Slider volumeFX;
 public Slider volumeMaster;
 public Toggle mute;
 [Header("Panels")]
 public GameObject mainPanel;
 public GameObject optionsPanel;
 public GameObject SelectPerson;
 public GameObject SelectColor;

 public void PlayLevel(string levelName)
 {
    SceneManager.LoadScene(levelName);
 }

 public void OpenPanel( GameObject panel)
 {
    mainPanel.SetActive(false);
    optionsPanel.SetActive(false);
    SelectPerson.SetActive(false);
    SelectColor.SetActive(false);

    panel.SetActive(true);
 }
}
