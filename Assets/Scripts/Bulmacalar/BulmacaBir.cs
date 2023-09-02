using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulmacaBir : MonoBehaviour
{
    public GameObject bulmaca1;
    void Start()
    {
        GameObject.FindGameObjectWithTag("Bulmaca").SetActive(false);
    }
 
    void Update()
    {
        if (BulmacaBirKarakter.isRestart)
        {
            Destroy(GameObject.FindGameObjectWithTag("Bulmaca"));
            GameObject bulmaca = Instantiate(bulmaca1, transform.position, Quaternion.identity);
            BulmacaBirKarakter.isRestart = false;
        }
    }
}
