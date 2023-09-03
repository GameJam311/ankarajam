using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SarBaba : MonoBehaviour
{
    public List<GameObject> images = new List<GameObject>();
    int currentIndex = 1;
    public GameEvent next;
    public GameObject pausepanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentIndex >= 5)
            {
                currentIndex = 5;
                next.Raise();
            }
            images[currentIndex].SetActive(true);
            currentIndex++;
        }
    }
    public void pausee()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void dewam()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void anamenu()
    {
        SceneManager.LoadScene("Ui");
    }
    public void exit()
    {
        Application.Quit();
    }
}
