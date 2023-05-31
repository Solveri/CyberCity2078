using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject Explode;
    [SerializeField] Rigidbody2D RotateBomb;

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateBomb.SetRotation(45);
    }
    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.name == "Collider")
        {
            gameObject.SetActive(false);
            Instantiate(Explode, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
