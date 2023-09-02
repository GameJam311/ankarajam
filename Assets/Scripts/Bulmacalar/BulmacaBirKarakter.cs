using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulmacaBirKarakter : MonoBehaviour
{
    bool up, down;
    public float speed;
    public Transform namlu;
    public GameObject mermi,gameOverText,Kazandin;

    void Update()
    {
        Hareket();
    }
    void Hareket()
    {
        if (up)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
        if (down)
        {
            transform.Translate(Vector3.down * (speed * Time.deltaTime));
        }
    }
    public void Up(bool yukari)
    {
        up = yukari;
    }
    public void Down(bool asagi)
    {
        down = asagi;
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(mermi, namlu.position, Quaternion.identity);
    }
    public static bool isRestart = false;
    IEnumerator GameOver()
    {
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameOverText.SetActive(false);
        isRestart = true;
    }
    IEnumerator Win()
    {
        Kazandin.SetActive(true);
        yield return new WaitForSeconds(1f);
        Kazandin.SetActive(false);
        KarakterKontroller.MiniGameTamam = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            StartCoroutine(GameOver());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bitis"))
        {
            StartCoroutine(Win());
        }
    }
}
