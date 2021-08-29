using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5.0f, 10.0f)]
    public float speed;
    public float jumpForce;

    public Transform containerTransform;
    public Inventory inventory;
 
    Rigidbody2D rb;

    bool doJump;
    bool isGrounded;

    const float EPSILON = 0.000001f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doJump = false;
        isGrounded = true;
    }

    void Update()
    {
        if (isGrounded && Input.GetButton("Jump"))
            doJump = true;
    }

    void FixedUpdate()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float hSpeed = 0; 
        
        // Bounds checking. I could use just objects off the edge of the screen but that breaks jumping so I'm
        //      doing it this way instead :D
        float screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        if ((hMove > 0 && rb.position.x + transform.localScale.x / 2.0f <= screenWidth)
            || (hMove < 0 && rb.position.x - transform.localScale.x / 2.0f >= -screenWidth))
            hSpeed = speed * hMove;
        rb.velocity = new Vector2(hSpeed, rb.velocity.y);

        // Only reason I'm doing it this way is I don't want the sprite to move when standing still.
        if (hMove < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            containerTransform.localScale = new Vector2(-1, 1);
        }
        else if (hMove > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            containerTransform.localScale = new Vector2(1, 1);
        }

        if (doJump && isGrounded)
        {
            doJump = false;
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else if (!isGrounded && rb.velocity.y <= 0)
        {
            // Make player fall faster to make jump less floaty feeling
            rb.gravityScale = 4;
        }
        else
            rb.gravityScale = 3;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            isGrounded = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            inventory.placeable[other.gameObject.GetComponent<PickupObject>().inventoryIndex].quantity += 1;
            Destroy(other.gameObject);
        }
    }

}