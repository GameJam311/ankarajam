using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontroller : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool getBattery = false;
    [SerializeField] GameObject f_light;
    public GameObject MainCamera,miniCam,MiniGame,pil;

    public static bool MiniGameTamam = false;


    [SerializeField] GameObject infoPanel;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.X) && getBattery)
        {
            if (f_light.activeSelf)
            {
                f_light.SetActive(false);
            }
            else
            {
                f_light.SetActive(true);
            }
        }

        Bulmaca();
        Flip();
    }
    void Bulmaca()
    {
        if (MiniGameTamam)
        {
            MainCamera.SetActive(true);
            miniCam.SetActive(false);
            pil.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Sandik")&&!MiniGameTamam)
        {
            MainCamera.SetActive(false);
            miniCam.SetActive(true);
            MiniGame.SetActive(true);
        }
        if (collision.CompareTag("Light"))
        {
            collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 500, transform.position.z);
            //infoPanel.SetActive(true);
            getBattery = true;
            //Time.timeScale = 0f;
        }
    }
}
