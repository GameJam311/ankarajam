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

    public void SahneGec(string sahne)
    {
        x = sahne;
        StartCoroutine(Karart());
    }
    IEnumerator Karart()
    {
        siyahPanel.SetTrigger("Karart");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(x);
    }
}
