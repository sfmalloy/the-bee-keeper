using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5.0f, 10.0f)]
    public float speed;
    public float jumpForce;

    public Transform containerTransform;
 
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
        rb.velocity = new Vector2(speed * hMove, rb.velocity.y);

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
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.08f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            isGrounded = true;
    }
}
