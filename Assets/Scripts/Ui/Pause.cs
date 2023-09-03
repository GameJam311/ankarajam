using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public string sahne;
    public Animator siyahPanel;
    public GameObject pausepanel;
    void Start()
    {
        
    }
  
    void Update()
    {
        if (KarakterKontroller.SahneGec)
        {
            StartCoroutine(Karart());
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
    IEnumerator Karart()
    {
        siyahPanel.SetTrigger("Karart");
        yield return new WaitForSeconds(1f);
        KarakterKontroller.SahneGec = false;
        SceneManager.LoadScene(sahne);
    }
}
