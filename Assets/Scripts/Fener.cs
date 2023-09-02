using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fener : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("HideObject"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
