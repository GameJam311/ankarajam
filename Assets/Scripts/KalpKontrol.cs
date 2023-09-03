using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KalpKontrol : MonoBehaviour
{
    public List<Image> kalps = new List<Image>();
    int currentkalp = 2;
    [SerializeField]
    public Sprite kalpeksiImage;

    public void kalpeksi()
    {
        kalps[currentkalp].sprite = kalpeksiImage;
        currentkalp--;
        if (currentkalp <= 0)
        {
            currentkalp = 0;
            //ölüm ekranýný buraya yazcan
        }    
        //kalp seslerini bura yazcan
    }
}
