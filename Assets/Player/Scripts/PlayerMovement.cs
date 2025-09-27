using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    ///[Header("Player Movement"")]
        public float  speed;
        public float  jumpForce;
        
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(inputX * speed*Time.deltaTime, inputY * speed*Time.deltaTime);
    }
}
