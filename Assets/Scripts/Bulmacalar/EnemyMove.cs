using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject pausepanel;
    void Update()
    {
        transform.Translate(Vector3.left * (3 * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pausepanel.SetActive(true);
    }
}
