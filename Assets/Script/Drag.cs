using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] Collider2D Life;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x == Life.transform.position.x && touch.position.y == Life.transform.position.y)
            {
                Debug.Log("Clicked");
            }

            else
            {
                Debug.Log(touch.position.x + " " + Life.transform.position.x + " " + touch.position.y + " " + Life.transform.position.y);
            }
        }
    }
}
