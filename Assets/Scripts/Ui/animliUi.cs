using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animliUi : MonoBehaviour
{
    Vector2 pos = new Vector2 (2.4f, 2.4f);
    private void OnEnable()
    {
        transform.DOScale(pos,1f).SetEase(Ease.OutElastic);
    }
}
