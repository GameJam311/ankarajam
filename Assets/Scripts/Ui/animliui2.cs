using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animliui2 : MonoBehaviour
{
    Vector2 pos = new Vector2(5f, 5f);
    private void OnEnable()
    {
        transform.DOScale(pos, 1f).SetEase(Ease.OutElastic);
    }
}
