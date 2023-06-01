using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameObject Bomb;

    private float Speed = 4f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movment of the Ship forward
        transform.Translate(Speed, 0, 0);

        //Limit of the ship
        if (transform.position.x <= -100 || transform.position.x >= 2100)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 24, 1);

            Speed *= -1;
        }
    }
}
