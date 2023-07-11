using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector2 touchedPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));

                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }

        else
        {
            transform.position = new Vector2(1600, 43);
        }
    }
}
