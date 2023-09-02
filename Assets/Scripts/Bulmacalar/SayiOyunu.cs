using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SayiOyunu : MonoBehaviour
{
    int randomSayi;
    int currentDigit;
    string hiddenNumber;
    float displayTimer = 0.5f;
    bool isDisplayingDigit = true;

    public Text numberText,inputText,rebember;
    public GameObject bulmaca,truePanel,FalsePanel;

    void Start()
    {
        
        GenerateRandomNumber();
        StartCoroutine(DisplayNumber());
    }

    void GenerateRandomNumber()
    {
        randomSayi = Random.Range(10000, 99999); // 10000 ile 99999 aras�nda 5 basamakl� bir rastgele say� olu�turabilirsiniz.
        hiddenNumber = randomSayi.ToString();
        currentDigit = 0;
    }

    IEnumerator DisplayNumber()
    {
        rebember.transform.DOScale(2f, 1f).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(1f);
        while (currentDigit < hiddenNumber.Length)
        {
            if (isDisplayingDigit)
            {
                numberText.text = numberText.text.Substring(0, currentDigit) + hiddenNumber[currentDigit];
                isDisplayingDigit = false;
            }
            else
            {
                numberText.text = numberText.text.Substring(0, currentDigit) + "*";
                isDisplayingDigit = true;
                currentDigit++;
            }

            yield return new WaitForSeconds(displayTimer);
        }

        // T�m rakamlar g�r�nd�, say�y� gizle
        numberText.text = new string('*', 5);
    }
    IEnumerator Wrong()
    {
        FalsePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        FalsePanel.SetActive(false);
        GenerateRandomNumber();
        StartCoroutine(DisplayNumber());
    }
    IEnumerator Correct()
    {
        truePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        bulmaca.SetActive(false);
        
    }
    public void Dogrula()
    {
        if (int.Parse(inputText.text) == randomSayi)
        {
            StartCoroutine(Correct());
        }
        else
        {
            inputText.text = "";
            StartCoroutine(Wrong());
        }
    }
    
}
