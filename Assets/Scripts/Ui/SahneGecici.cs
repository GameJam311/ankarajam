using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecici : MonoBehaviour
{
    public Animator siyahPanel;
    string x;
    void Start()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SahneGec(string sahne)
    {
        
        
            x = sahne;
        Time.timeScale = 1f;
        StartCoroutine(Karart());
        
        
    }
    IEnumerator Karart()
    {
        siyahPanel.SetTrigger("Karart");
        yield return new WaitForSeconds(1f);
        
        KarakterKontroller.SahneGec = false;
        SceneManager.LoadScene(x);
    }
}
