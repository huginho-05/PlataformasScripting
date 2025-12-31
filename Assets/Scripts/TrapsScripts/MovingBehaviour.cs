using UnityEngine;

public class MovingBehaviour : MonoBehaviour
{
    [SerializeField] private float speedObject;
    
    [SerializeField] private Vector3 direccionInicial;
    
    [SerializeField] private float timerObject;
    
    private Vector3 direccionActual;

    private float timer;
    
    void Start()
    {
        direccionActual = direccionInicial;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direccionActual * speedObject * Time.deltaTime);
        
        if (timer >= timerObject)
        {
            direccionActual *= -1;
            timer = 0;
        }
    }
}
