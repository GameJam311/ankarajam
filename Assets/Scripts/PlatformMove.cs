using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] GameObject left, right;
    void Start()
    {
        if (transform.CompareTag("dikey"))
        {
            InvokeRepeating("loopstartdd", 0f, 5f);
        }
        else
        {
            InvokeRepeating("loopstart", 0f, 5f);
        }     
    }

    void loopstart()
    {
        StartCoroutine("loop");
    }
    IEnumerator loop()
    {
        transform.DOMoveX(right.transform.position.x, 2f);
        yield return new WaitForSeconds(2f);
        transform.DOMoveX(left.transform.position.x, 2f);
        yield return new WaitForSeconds(2f);
    }
    void loopstartdd()
    {
        StartCoroutine("loopdd");
    }
    IEnumerator loopdd()
    {
        transform.DOMoveY(right.transform.position.y, 2f);
        yield return new WaitForSeconds(2f);
        transform.DOMoveY(left.transform.position.y, 2f);
        yield return new WaitForSeconds(2f);
    }
}
