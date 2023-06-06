using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] GameObject Falling_Object;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Falling_Object.SetActive(true);
            Falling(touch);
        }
    }

    private void Falling(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                Falling_Object.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
                break;

            case TouchPhase.Moved:
                Falling_Object.transform.position = new Vector2(touch.position.x, touch.position.y);
                break;

            case TouchPhase.Ended:
                Debug.Log("End Touch");
                transform.Translate(0, -200, 0);
                break;
        }
    }
}
