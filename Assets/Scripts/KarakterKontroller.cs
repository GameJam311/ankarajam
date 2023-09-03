using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontroller : MonoBehaviour
{
    private float horizontal;
    public float speed = 10f;
    public float jumpingPower = 20f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool getBattery = false;
    [SerializeField] GameObject f_light;
    public GameObject MainCamera,miniCam,MiniGame,pil,fenerke;

    public static bool MiniGameTamam = false;

    [SerializeField] GameObject infoPanel;
    AudioSource aSource;
    Animator anim;
    public AudioClip jump, damage,gameStart,button,collect;
    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        MiniGameTamam = false;
        
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            aSource.PlayOneShot(jump, 1f);
            anim.SetTrigger("jump");
            StartCoroutine("jumpwait");
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            anim.SetTrigger("jump");
            StartCoroutine("jumpwait");
        }
        if (Input.GetKeyDown(KeyCode.X) && getBattery)
        {
            aSource.PlayOneShot(button, 1f);
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
            aSource.PlayOneShot(gameStart, 1f);
            MainCamera.SetActive(false);
            miniCam.SetActive(true);
            MiniGame.SetActive(true);
        }
        if (collision.CompareTag("Light"))
        {
            aSource.PlayOneShot(collect, 1f);
            collision.gameObject.transform.position = new Vector3(transform.position.x+5000, transform.position.y - 5000, transform.position.z+5000);
            //infoPanel.SetActive(true);
            getBattery = true;
            //Time.timeScale = 0f;
        }
    }
    IEnumerator jumpwait()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetTrigger("backidle");
    }
    public void tutorialstuff()
    {
        fenerke.SetActive(true);
    }
}
