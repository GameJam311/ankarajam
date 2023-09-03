using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PilTweening : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOMoveY(transform.position.y + 0.5f, 0.7f).SetLoops(-1,LoopType.Yoyo);
    }
}
