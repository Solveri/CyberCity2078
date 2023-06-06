using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] GameObject Falling_Object;

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Falling_Object.active = true;
                    Falling_Object.transform.position = new Vector2(touch.position.x, touch.position.y);
                    break;

                case TouchPhase.Moved:
                    int Speed =+ 1;
                    Falling_Object.transform.Translate(0, Speed, 0);
                    break;

                case TouchPhase.Ended:
                    Speed = 1;
                    Falling_Object.transform.Translate(0, Speed, 0);
                    break;
            }
        }
    }
}
