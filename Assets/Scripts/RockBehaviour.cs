using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    [SerializeField] private float rockSpeed;
    private Vector2 posicionInicial;
    [SerializeField] private Vector2 posicionFinal;
    private bool playerInside;
    
    private void Start()
    {
        // Posición inicial de la roca
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (playerInside)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, rockSpeed * Time.deltaTime);
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, rockSpeed * Time.deltaTime);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        // Cuando el jugador entra en el trigger
        if (other.CompareTag("Player"))
        {
            playerInside = true;  
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Cuando el jugador sale del trigger
        if (other.CompareTag("Player"))
        {
            playerInside = false;  
        }
    }
    
}
