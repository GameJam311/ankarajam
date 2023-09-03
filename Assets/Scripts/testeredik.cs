using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeredik : MonoBehaviour
{
    [SerializeField] GameObject left, right;
    void Start()
    {
        InvokeRepeating("loopstart", 0f, 3.5f);
    }

    void loopstart()
    {
        StartCoroutine("loop");
    }
    IEnumerator loop()
    {
        transform.DOMoveY(right.transform.position.y, 1.5f);
        yield return new WaitForSeconds(1f);
        transform.DOMoveY(left.transform.position.y, 1.5f);
        yield return new WaitForSeconds(1f);
    }
}
