using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.left * (3 * Time.deltaTime));
    }
}
