using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject Explode;
    [SerializeField] Rigidbody2D RotateBomb;
    [SerializeField] GameObject AirPlaine;

    [System.Obsolete]
    private void Start()
    {
        gameObject.SetActive(false);

        Explode.SetActive(false);

        if (tag == "1") { Invoke("Spawn", 1f); }

        if (tag == "2") { Invoke("Spawn", 4f); }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateBomb.SetRotation(45);

        Explode.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.name == "Collider")
        {
            gameObject.SetActive(false);

            Explode.transform.position = new Vector2(transform.position.x, transform.position.y);

            Explode.SetActive(true);
        }
    }

    void Spawn()
    {
        float SpawnInterval = 9f;
        transform.position = new Vector2(AirPlaine.transform.position.x, AirPlaine.transform.position.y);
        Invoke("Spawn", SpawnInterval);
        gameObject.SetActive(true);
    }
}
