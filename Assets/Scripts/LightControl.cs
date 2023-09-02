using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    [SerializeField] GameObject battery;
    [SerializeField] GameObject infoPanel;
    public KarakterKontroller kontroller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            battery.SetActive(false);
            infoPanel.SetActive(true);
            kontroller.getBattery = true;
            Time.timeScale = 0f;
        }
    }
}
