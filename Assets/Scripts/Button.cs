using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    public void ButtonSound(AudioClip ses)
    {
        aSource.PlayOneShot(ses, 1f);
    }
}
