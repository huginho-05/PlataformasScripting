using UnityEngine;

public class RinoBehaviour : MonoBehaviour
{
    [SerializeField] private float rinoSpeed;
    
    [SerializeField] private Vector3 direccionInicial;
    
    [SerializeField] private float timerBall;
    
    private Vector3 direccionActual;

    private float timer;
    
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        direccionActual = direccionInicial;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direccionActual * rinoSpeed * Time.deltaTime);
        
        if (direccionActual.x > 0)
            spriteRenderer.flipX = true; 
        else if (direccionActual.x < 0)
            spriteRenderer.flipX = false;  
        
        if (timer >= timerBall)
        {
            direccionActual *= -1;
            timer = 0;
        }
    }
    
}
