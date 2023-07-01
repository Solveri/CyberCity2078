using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform SpawnEnemy;


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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Enemy" || other.name == "Enemy(Clone)")
        {
            other.transform.position = SpawnEnemy.position;
            Destroy(gameObject);
        }
    }

}
