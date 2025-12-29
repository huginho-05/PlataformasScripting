using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private Animator rockMovementAnimator;
    
    [SerializeField] private float rockSpeed;
    
    [SerializeField] private Vector3 direccionIda;
    
    [SerializeField] private Vector3 direccionVuelta;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.y == 0)
        {
            rockMovementAnimator.SetBool("isMoving", false);
        }
        else
        {
            rockMovementAnimator.SetBool("isMoving", true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.Translate(direccionIda * rockSpeed);
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.Translate(direccionVuelta * rockSpeed);
        }
        
    }
    
    
}
