using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] Rigidbody2D Sign1;
    [SerializeField] Animator SignAnimation1;
    [SerializeField] Animator SignAnimation2;

    Vector3 SignPosition;

    void Start()
    {
        Sign1.bodyType = RigidbodyType2D.Static;

        SignPosition = Sign1.position;
    }

    // Update is called once per frame
    void Update()
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
                SignAnimation1.SetBool("Touched", true);
                SignAnimation2.SetBool("Touched", true);
                break;

            case TouchPhase.Moved:
                SignAnimation1.SetBool("Touched", true);
                SignAnimation2.SetBool("Touched", true);
                break;

            case TouchPhase.Ended:
                SignAnimation1.SetBool("Touched", false);
                SignAnimation2.SetBool("Touched", false);
                Sign1.bodyType = RigidbodyType2D.Dynamic;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.Translate(0, SignPosition.y - transform.position.y, 0);
        Sign1.bodyType = RigidbodyType2D.Static;
    }
}
