using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SarBaba2 : MonoBehaviour
{
    public List<GameObject> images = new List<GameObject>();
    int currentIndex = 1;
    public GameEvent next;
    public AudioClip zort;
    AudioSource ses;
    private void Start()
    {
        ses = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ses.PlayOneShot(zort, 1f);
            if (currentIndex >= 4)
            {
                currentIndex = 4;
                next.Raise();
            }
            images[currentIndex].SetActive(true);
            currentIndex++;
        }
    }
}
