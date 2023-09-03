using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalpKontrol : MonoBehaviour
{
    public List<GameObject> kalps = new List<GameObject>();
    int currentkalp = 2;

    public void kalpeksi()
    {
        if(currentkalp <= 0)
        {
            currentkalp = 0;
            //ölüm ekranýný buraya yazcan
        }
        kalps[currentkalp].SetActive(false);
        currentkalp--;
        //kalp seslerini bura yazcan
    }
}
