using UnityEngine;
using System.Collections;

public class FireBehaviour : MonoBehaviour
{
    private Collider2D triggerCollider;

    [Header("Configuración del Timer")]
    [SerializeField] private  float tiempoActivado;  // Tiempo que el trigger estará activado
    [SerializeField] private  float tiempoDesactivado;  // Tiempo que el trigger estará desactivado
    [SerializeField] private Animator fireAnimator;

    void Start()
    {
        // Obtener el Collider2D del GameObject (el trigger)
        triggerCollider = GetComponent<Collider2D>();

        // Iniciar la coroutine para alternar el estado del trigger
        StartCoroutine(ActivarFuego());
    }

    IEnumerator ActivarFuego()
    {
        while (true) // Esto hará que la coroutine se ejecute continuamente
        {
            // Activar el trigger
            triggerCollider.enabled = true;
            fireAnimator.SetBool("fireOn", true);
            yield return new WaitForSeconds(tiempoActivado);

            // Desactivar el trigger
            triggerCollider.enabled = false;
            fireAnimator.SetBool("fireOn", false);
            yield return new WaitForSeconds(tiempoDesactivado);
        }
    }
}
