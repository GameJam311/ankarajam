using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float fireRate = 2f; // Ateş hızı (saniye cinsinden)
    public float bulletSpeed = 10f;

    private float nextFireTime; // Bir sonraki ates zamani

    void Start()
    {
        nextFireTime = Time.time + fireRate;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Bir sonraki ates zamani
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        // Mermiye yukarıya dogru hareket vermek için transform pozisyonunu guncelleme
        bullet.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
