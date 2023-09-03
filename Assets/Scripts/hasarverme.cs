using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasarverme : MonoBehaviour
{
    public GameEvent damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damage.Raise();
        }
    }
}
