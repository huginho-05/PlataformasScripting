using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    
    [SerializeField] private Animator playerMovementAnimator;
    private SpriteRenderer spriteRenderer;
    
    public bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        //Animaciones ascenso y caida
        playerMovementAnimator.SetFloat("SpeedY", rb.linearVelocity.y);
    }
    
    private void FixedUpdate()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); 
        
        rb.linearVelocity = new Vector2(hInput * playerSpeed, rb.linearVelocity.y);

        //Animaciones Idle y Correr
        if (hInput != 0)
        {
            playerMovementAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerMovementAnimator.SetBool("isRunning", false);
        }
        
        //Cambiar la dirección del sprite
        if (hInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (hInput < 0)
        {
            spriteRenderer.flipX = true;
        }

    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            playerMovementAnimator.SetBool("isGrounded", true);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
            playerMovementAnimator.SetBool("isGrounded", false);
        }
    }
}
