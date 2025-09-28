using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float idleTimer;
    float doubleJump = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = walkingSprites[0];
        currentFrame = 0;
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = new Vector2(-25, 0);
            Health--;
        }

        if (Health <= 0)
        {
            Application.Quit();
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
                {
                   currentFrame = 0;
                }
                sr.sprite = walkingSprites[currentFrame];
            }
        }
        if(Grounded() && movement.magnitude == 0)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= frameRate)
            {
                idleTimer = 0f;
                currentFrame++;
                if (currentFrame >= idleSprites.Length)
                {
                    currentFrame = 0;
                }
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
        if(Input.GetKeyDown(KeyCode.LeftControl))
            speed /= 2;
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            speed *= 2;
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