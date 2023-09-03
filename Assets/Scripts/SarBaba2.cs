using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SarBaba2 : MonoBehaviour
{
    public List<GameObject> images = new List<GameObject>();
    int currentIndex = 1;
    public GameEvent next;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex >= 4)
            {
                currentIndex = 4;
                next.Raise();
            }
            images[currentIndex].SetActive(true);
            currentIndex++;
        }
    }
}
