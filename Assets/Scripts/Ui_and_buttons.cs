using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_and_buttons : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    public void understand()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Starter()
    {
        SceneManager.LoadScene("Giris");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
