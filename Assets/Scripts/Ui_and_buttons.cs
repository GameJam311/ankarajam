using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_and_buttons : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    public void understand()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
