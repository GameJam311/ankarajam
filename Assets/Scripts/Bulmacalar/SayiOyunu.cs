using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayiOyunu : MonoBehaviour
{
    int randomSayi;
    int inputSayi;

    public Text input, random;
    public GameObject truePanel, falsePanel, info,bulmaca;
    void Start()
    {
        StartCoroutine(Info());
    }

    
    void Update()
    {
        
    }
    
    public void Dogrula()
    {
        string x = input.text;
        inputSayi = int.Parse(x);
        if (inputSayi == randomSayi)
        {
            StartCoroutine(Correct());
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }
    void RandomSayi()
    {
        randomSayi = Random.Range(10000, 100000);
        random.text = "" + randomSayi;
    }
    IEnumerator Correct()
    {
        truePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        bulmaca.SetActive(false);
    }
    IEnumerator Wrong()
    {
        falsePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        falsePanel.SetActive(false);
        StartCoroutine(Info());
    }
    IEnumerator Info()
    {
        info.SetActive(true);
        input.text = "";
        yield return new WaitForSeconds(1f);
        info.SetActive(false);
        RandomSayi();
        random.enabled = true;
        yield return new WaitForSeconds(1f);
        random.enabled = false;
    }
}
