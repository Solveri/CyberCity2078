using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    private bool Dragging = false;

    [SerializeField] SpriteRenderer Falling_Object;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Falling(touch);
        }
    }

    private void Falling(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                Falling_Object.enabled = true;
                Falling_Object.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
                break;

            case TouchPhase.Moved:
                Falling_Object.transform.position = new Vector2(touch.position.x, touch.position.y);
                break;

            case TouchPhase.Ended:
                transform.Translate(0, 4, 0);
                break;
        }
    }
}
