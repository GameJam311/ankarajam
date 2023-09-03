using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cod_of_testere : MonoBehaviour
{
    [SerializeField] GameObject left, right;
    void Start()
    {
        InvokeRepeating("loopstart", 0f, 3f);
    }

    void loopstart()
    {
        StartCoroutine("loop");
    }
    IEnumerator loop()
    {
        transform.DOMoveX(right.transform.position.x, 1f);
        yield return new WaitForSeconds(1f);
        transform.DOMoveX(left.transform.position.x, 1f);
        yield return new WaitForSeconds(1f);
    }
}
