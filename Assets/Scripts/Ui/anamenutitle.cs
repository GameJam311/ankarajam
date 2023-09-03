using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class anamenutitle : MonoBehaviour
{
    Vector2 pos = new Vector2(7.2f, 7.2f);
    private void OnEnable()
    {
        transform.DOScale(pos, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
