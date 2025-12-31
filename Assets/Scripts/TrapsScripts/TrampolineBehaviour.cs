using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto; // La fuerza con la que se lanza el jugador
    [SerializeField] private Animator trampolineAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>(); // Obtener el Rigidbody2D del jugador
            
            trampolineAnimator.SetBool("playerJumps", true);
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Limpiar cualquier velocidad previa en el eje Y
            
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse); // Aplicar el impulso hacia arriba
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trampolineAnimator.SetBool("playerJumps", false);
        }
    }
    
}
