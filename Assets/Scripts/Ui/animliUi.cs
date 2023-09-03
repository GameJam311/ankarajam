using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animliUi : MonoBehaviour
{
    public float scalevalue, floattime;
    
    private void OnEnable()
    {
        Vector2 pos = new Vector2(scalevalue, floattime);
        transform.DOScale(pos,1f).SetEase(Ease.OutElastic);
    }
}
