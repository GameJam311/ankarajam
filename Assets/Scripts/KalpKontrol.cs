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
    AudioSource ses;
    public AudioClip damage;
    public GameObject GameOver;
    private void Start()
    {
        ses = GetComponent<AudioSource>();
        GameOver.SetActive(false);
        KarakterKontroller.GameOver = false;
    }
    public void kalpeksi()
    {
        kalps[currentkalp].sprite = kalpeksiImage;
        currentkalp--;
        if (currentkalp <= 0)
        {
            currentkalp = 0;
            KarakterKontroller.GameOver = true;
            GameOver.SetActive(true);
        }
        if (!KarakterKontroller.GameOver)
        {
            ses.PlayOneShot(damage, 1f);
        }
        
    }
}
