using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] float bulletSpeed = 15f;

    private void Start()
    {
        rb.velocity = transform.right * bulletSpeed * Time.deltaTime;
        StartCoroutine(DestoryRoutine());
    }

    private IEnumerator DestoryRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy" || collision.name == "Enemy(Clone)")
        {
            collision.gameObject.SendMessage("KillEnemy");
        }
    }

}
