using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_and_buttons : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject tutorialpanel;
    public void understand()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Starter()
    {
        SceneManager.LoadScene("GirisSinematik");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PauseExit()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void tutorialexit()
    {
        tutorialpanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
