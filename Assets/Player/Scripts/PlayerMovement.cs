using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Sprite[] walkingSprites;  // Assign your sprites in the inspector
    public float frameRate = 0.1f;
    public float jumpForce = 5f;
    public float jumpDistance = 5f;
    public LayerMask Ground;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private int currentFrame;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        // Animate only if moving
        if (movement.x > 0)
            sr.flipX = false;  // facing right
        else if (movement.x < 0)
            sr.flipX = true;   // facing left
        if (movement.magnitude > 0)
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                currentFrame++;
                if (currentFrame >= walkingSprites.Length)
                    currentFrame = 0;
                sr.sprite = walkingSprites[currentFrame];
            }
        }
        else
        {
            // Reset to idle sprite (optional)
            sr.sprite = walkingSprites[0];
            currentFrame = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }
    private bool Grounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, jumpDistance,Ground))
            return true;
        return false;
    }
}