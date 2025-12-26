using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator playerMovementAnimator;
    
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    
    private void FixedUpdate()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); 
        
        rb.linearVelocity = new Vector2(hInput * playerSpeed, rb.linearVelocity.y);

        if (hInput != 0)
        {
            playerMovementAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerMovementAnimator.SetBool("isRunning", false);
        }

    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true; 
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
