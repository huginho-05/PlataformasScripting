using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    
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
        
        Vector2 movementDirection  = new Vector2 (hInput, 0).normalized;
        
        transform.Translate(movementDirection * (playerSpeed * Time.deltaTime), Space.World);

    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true; 
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
