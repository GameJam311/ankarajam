using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulmaca2Hareket : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    bool Zeminde = false;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && Zeminde)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Zemin"))
        {
            Zeminde = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Zemin"))
        {
            Zeminde = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Kapi"))
        {
            KarakterKontroller.MiniGameTamam = true;
        }
        if (collision.gameObject.tag.Equals("Buton"))
        {
            
        }
    }
}
