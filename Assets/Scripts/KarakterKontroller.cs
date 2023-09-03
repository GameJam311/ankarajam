using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject MainCamera, miniCam, MiniGame, pil;

    public static bool MiniGameTamam = false;

    [SerializeField] GameObject infoPanel;
    AudioSource aSource;
    Animator anim;
    Animator camanim;
    public AudioClip jump, damage, gameStart, button, collect;

    [Header("Geri Tepme")]
    public float backwardForceMultiplier = 5f;
    public static bool SahneGec = false;
    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        MiniGameTamam = false;
        camanim = Camera.main.GetComponent<Animator>();

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Sandik") && !MiniGameTamam)
        {
            aSource.PlayOneShot(gameStart, 1f);
            MainCamera.SetActive(false);
            miniCam.SetActive(true);
            MiniGame.SetActive(true);
        }
        if (collision.CompareTag("Light"))
        {
            aSource.PlayOneShot(collect, 1f);
            collision.gameObject.transform.position = new Vector3(transform.position.x + 5000, transform.position.y - 5000, transform.position.z + 5000);
            //infoPanel.SetActive(true);
            getBattery = true;
            //Time.timeScale = 0f;
        }
        if (collision.CompareTag("saw"))
        {
            Debug.Log("geri tepti");
            Recoil();

        }
        if (collision.CompareTag("Portal"))
        {
            SahneGec = true;
        }

    }
    IEnumerator jumpwait()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetTrigger("backidle");
    }
    public void Recoil()// geri tepme
    {

        Debug.Log("geri tepti:" + backwardForceMultiplier);
        Vector2 backwardVelocity = -transform.right * backwardForceMultiplier;
        rb.velocity = backwardVelocity;

        if (isFacingRight != isFacingRight)
        {
            Flip();
            backwardVelocity = transform.right * backwardForceMultiplier;
            rb.velocity = backwardVelocity;
        }

    }
}
