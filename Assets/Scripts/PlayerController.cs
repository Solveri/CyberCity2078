using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 Dir() {{ return dir; }  }
    public InputKeyController UpKey;
    public InputKeyController DownKey;
    public InputKeyController LeftKey;
    public InputKeyController RightKey;
    public InputKeyController SwingKey;
    public InputKeyController ShootKey;


    public float speed = 5f;
    public float jumpForce = 5f;
    public float swingCooldown = 0.5f;
    public float gunCooldown = 1f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;

    [SerializeField] GameObject ShootPoint;
    [SerializeField] GameObject BulletPreFabs;
    [SerializeField] Transform parentTransform;

    [SerializeField] Transform groundPoint;
    public  bool isGrounded;
    public bool HasSwang = false;
    public bool HasShot = false;
    public bool isLeft = false;
    

    private GameObject newBullet;
    List<GameObject> bulletsInGame = new List<GameObject>();
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
            if (!isLeft)
            {
                transform.Rotate(0, 180, 0);
                isLeft = true;
            }
            


        }
        else if (RightKey.key == InputKeyController.Keys.Right && RightKey.isPressed && isGrounded)
        {
            dir = Vector2.right;
            rb.velocity = new Vector2(dir.x * speed * Time.fixedDeltaTime, 0);
            if (isLeft)
            {
               
                transform.eulerAngles = new Vector3(0, 0, 0);
                isLeft = false;
            }
            
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        if (UpKey.key == InputKeyController.Keys.Up && UpKey.isPressed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(SwingKey.key == InputKeyController.Keys.Swing && SwingKey.isPressed && !HasSwang)
        {
            anim.SetTrigger("Attack");
            HasSwang = true;
            StartCoroutine(RestSwing(swingCooldown));
        }
        else if (ShootKey.key == InputKeyController.Keys.Shoot && ShootKey.isPressed && !HasShot)
        {
            anim.SetTrigger("Shoot");
            HasShot = true;
            ShootBullet();
            StartCoroutine(RestGun(gunCooldown));
        }
       

       

       
        


    }
    private IEnumerator RestSwing(float delay)
    {
        yield return new WaitForSeconds(delay);
        HasSwang = false;
    }
    private IEnumerator RestGun(float delay)
    {
        yield return new WaitForSeconds(delay);
        HasShot = false;
    }
    public void ShootBullet()
    {
        newBullet = Instantiate(BulletPreFabs, ShootPoint.transform.position, ShootPoint.transform.rotation);
      
        
        
    }
   
        
  



}
