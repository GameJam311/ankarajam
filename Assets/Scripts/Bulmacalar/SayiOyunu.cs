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
    public GameObject bulmaca;
    public InputField inputField;
    public Image isik;
    public Sprite yesil;

    public AudioClip wrong, correct;
    AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        GenerateRandomNumber();
        StartCoroutine(DisplayNumber());
    }

    void GenerateRandomNumber()
    {
        randomSayi = Random.Range(10000, 99999); // 10000 ile 99999 arasýnda 5 basamaklý bir rastgele sayý oluþturabilirsiniz.
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

        // Tüm rakamlar göründü, sayýyý gizle
        numberText.text = new string('*', 5);
    }
    IEnumerator Wrong()
    {
        aSource.PlayOneShot(wrong, 1f);
     
        yield return new WaitForSeconds(0.5f);
        
        GenerateRandomNumber();
        StartCoroutine(DisplayNumber());
    }
    IEnumerator Correct()
    {
        aSource.PlayOneShot(correct, 1f);
        isik.GetComponent<Image>().sprite = yesil;
       
        yield return new WaitForSeconds(1f);
        bulmaca.SetActive(false);
        KarakterKontroller.MiniGameTamam = true;
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
            inputField.text = "";
            StartCoroutine(Wrong());
        }
    }
    
}
