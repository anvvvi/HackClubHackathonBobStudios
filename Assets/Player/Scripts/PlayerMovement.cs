using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Sprite[] walkingSprites;  // Assign your sprites in the inspector
    public float frameRate = 0.1f;

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
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animate only if moving
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
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}