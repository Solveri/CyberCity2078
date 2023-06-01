using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    
    public float bulletSpeed = 15f;


    private void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
   

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hey");
    }

}
