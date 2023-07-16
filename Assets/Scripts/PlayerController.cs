using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool HasSwang = false;

    //public Vector2 Dir() {{ return dir; }  }
    [SerializeField] InputKeyController UpKey;
    [SerializeField] InputKeyController DownKey;
    [SerializeField] InputKeyController LeftKey;
    [SerializeField] InputKeyController RightKey;
    [SerializeField] InputKeyController SwingKey;
    [SerializeField] InputKeyController ShootKey;

    //public LayerMask groundLayer;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float swingCooldown = 0.5f;
    [SerializeField] float gunCooldown = 1f;
    [SerializeField] static bool isGrounded; //In the enemy script
    [SerializeField] bool hasShot = false;
    [SerializeField] bool isLeft = false;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] EnemyScript killEnemy;

    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject bulletPreFabs;

    [SerializeField] Transform parentTransform;
    [SerializeField] Transform groundPoint;
    [SerializeField] Transform spawnEnemy;
    [SerializeField] Transform teleportPosition;

    private GameObject newBullet;
    //List<GameObject> bulletsInGame = new List<GameObject>();
    private Vector2 dir;
    private float PlayerPosY = 0;

    // Update is called once per frame
    void Update()
    { 
        //isGrounded = Physics2D.OverlapCapsule(groundPoint.position, new Vector2(0.94f, 0.17f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("MoveX", Mathf.Abs(rb.velocity.x));

        //This method activate when the player move to the right or the left
        if(isGrounded == false)
        {
            PlayerPosY = -43;
        }

        else 
        { 
            PlayerPosY = 0; 
        }

        if (transform.position.x < 0)
        {
            transform.position = new Vector2(transform.position.x + 20, transform.position.y);
        }

        else if (transform.position.x > Screen.width)
        {
            transform.position = new Vector2(transform.position.x - 20, transform.position.y);
            Debug.Log(transform.position.x);
        }
    }

    private void FixedUpdate()
    {
        if (LeftKey.key == InputKeyController.Keys.Left && LeftKey.isPressed)
        {
            dir = Vector2.left;
            rb.velocity = new Vector2(dir.x * speed * Time.fixedDeltaTime, rb.velocity.y);
            if (!isLeft)
            {
                transform.Rotate(0, 180, 0);
                isLeft = true;
            }
        }

        else if (RightKey.key == InputKeyController.Keys.Right && RightKey.isPressed)
        {
            dir = Vector2.right;
            rb.velocity = new Vector2(dir.x * speed * Time.fixedDeltaTime, rb.velocity.y);
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

        else if (ShootKey.key == InputKeyController.Keys.Shoot && ShootKey.isPressed && !hasShot)
        {
            anim.SetTrigger("Shoot");
            hasShot = true;
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
        hasShot = false;
    }

    public void ShootBullet()
    {
        newBullet = Instantiate(bulletPreFabs, shootPoint.transform.position, shootPoint.transform.rotation);      
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "Collider")
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", isGrounded);
        }

        if(other.collider.name == "Elevators")
        {
            transform.position = new Vector2(teleportPosition.position.x, teleportPosition.position.y);
        }

        if (other.collider.name == "Ladder")
        {
            transform.position = new Vector2(teleportPosition.position.x, teleportPosition.position.y);
        }

        if (other.collider.name == "Enemy" || other.collider.name == "Enemy(Clone)")
        {
            if (HasSwang)
            {
                if (killEnemy != null)
                {
                    other.collider.transform.position = spawnEnemy.position;
                    killEnemy.KillEnemy();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.name == "Collider")
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", isGrounded);
        }

        if (other.collider.name == "Enemy" || other.collider.name == "Enemy(Clone)")
        {
            //Invoke("Grounded", 0.01f);
        }
    }

    public void Grounded()
    {
        isGrounded = false;
    }
}
