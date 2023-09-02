using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float bulletSpeed = 10f; 

    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);//yukari firlat
        Destroy(gameObject, 3f);
    }
}
