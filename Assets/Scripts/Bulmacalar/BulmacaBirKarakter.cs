using UnityEngine;

public class BulmacaBirKarakter : MonoBehaviour
{
    bool up, down;
    public float speed;
    public Transform namlu;
    public GameObject mermi;
    void Start()
    {
        
    }

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            print("oyun bitti");
        }
    }
}
