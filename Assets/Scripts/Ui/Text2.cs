using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Text2 : MonoBehaviour
{
    Vector2 pos = new Vector2(1.1f, 1.1f);
    public TextMeshProUGUI next;
    bool altýoldu = false;

    private void OnEnable()
    {
        transform.DOScale(pos, 1f).SetLoops(-1, LoopType.Yoyo);
    }
    public void textxchange()
    {
        next.text = "Press Space for Back to Main Menu";
        altýoldu = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && altýoldu)
        {
            SceneManager.LoadScene("Ui");
        }
    }
}
