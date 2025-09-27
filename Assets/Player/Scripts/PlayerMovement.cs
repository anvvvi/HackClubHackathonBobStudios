using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Sprite[] walkingSprites;
    public Sprite[] idleSprites;  // Assign your sprites in the inspector
    public float frameRate = 0.1f;
    public float jumpForce = 5f;
    public float jumpDistance = 5f;
    public LayerMask Ground;
    public int Health = 3;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private int currentFrame;
    private float timer;
    float doubleJump = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = new Vector2(-25, 0);
            Health--;
        }

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
        else if(Grounded())
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                currentFrame++;
                if (currentFrame >= idleSprites.Length)
                    currentFrame = 0;
                sr.sprite = idleSprites[currentFrame];
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && (doubleJump <2 || Grounded()))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            doubleJump++;
            Debug.Log(doubleJump);
        }
        else if(doubleJump >=2 && Grounded())
        {
            Debug.Log(doubleJump);
            doubleJump = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
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