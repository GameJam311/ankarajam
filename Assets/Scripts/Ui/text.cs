using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class text : MonoBehaviour
{
    Vector2 pos = new Vector2(2.1f, 2.1f);
    public TextMeshProUGUI next;
    bool altýoldu = false;

    private void OnEnable()
    {
        transform.DOScale(pos, 1f).SetLoops(-1, LoopType.Yoyo);
    }
    public void textxchange()
    {
        next.text = "Press Space for Game";
        altýoldu = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && altýoldu)
        {
            SceneManager.LoadScene("level_1");
        }
    }
}
