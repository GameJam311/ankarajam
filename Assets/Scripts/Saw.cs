using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public KarakterKontroller player;

    void Start()
    {
        player = FindObjectOfType<KarakterKontroller>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("degdi");
            player.Recoil();
        }

    }
}
