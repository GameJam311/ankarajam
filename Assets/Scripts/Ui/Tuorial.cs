using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuorial : MonoBehaviour
{
    public GameObject tutorialpanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorialpanel.SetActive(true);
            Time.timeScale = 0f;
            this.gameObject.SetActive(false);
        }      
    }
}
