using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    [SerializeField] private float speedSaw;
    
    [SerializeField] private Vector3 direccionInicial;
    
    [SerializeField] private float timerSaw;
    
    private Vector3 direccionActual;

    private float timer;
    
    void Start()
    {
        direccionActual = direccionInicial;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direccionActual * speedSaw * Time.deltaTime);
        
        if (timer >= timerSaw)
        {
            direccionActual *= -1;
            timer = 0;
        }
    }
}
