using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputKeyController UpKey;
    public InputKeyController DownKey;
    public InputKeyController LeftKey;
    public InputKeyController RightKey;
    public InputKeyController SwingKey;
   

    public float speed = 5f;
    public float jumpForce = 5f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;

    [SerializeField] Transform groundPoint;
    public  bool isGrounded;
    public bool HasSwang = false;

    public LayerMask groundLayer;

    private Vector2 dir;


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        isGrounded = Physics2D.OverlapCapsule(groundPoint.position, new Vector2(0.94f, 0.17f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("MoveX", Mathf.Abs(rb.velocity.x));

    }
    private void FixedUpdate()
    {

        if (LeftKey.key == InputKeyController.Keys.Left && LeftKey.isPressed && isGrounded)
        {
            dir = Vector2.left;
            rb.velocity = new Vector2(dir.x * speed * Time.fixedDeltaTime, 0);
            sr.flipX = true;

        }
        else if (RightKey.key == InputKeyController.Keys.Right && RightKey.isPressed && isGrounded)
        {

            dir = Vector2.right;
            rb.velocity = new Vector2(dir.x * speed * Time.fixedDeltaTime, 0);
            sr.flipX = false;
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (UpKey.key == InputKeyController.Keys.Up && UpKey.isPressed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(SwingKey.key == InputKeyController.Keys.Swing && SwingKey.isPressed && isGrounded && !HasSwang)
        {
            anim.SetTrigger("Attack");
            HasSwang = true;
            StartCoroutine(SwingCoolDown());
        }
       

       

       
        


    }
    private IEnumerator SwingCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        HasSwang = false;
    }
   


}
