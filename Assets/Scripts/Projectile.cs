using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    
    public float bulletSpeed = 15f;
    public float lifeTime = 3f;
    

    private void Start()
    {
        rb.velocity = transform.right * bulletSpeed * Time.deltaTime;
        StartCoroutine(DestoryRoutine());
    }
    // Start is called before the first frame update

    private IEnumerator DestoryRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hey");
    }

}
