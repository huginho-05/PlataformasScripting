using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    [SerializeField] private Animator turtleAnimator;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            turtleAnimator.SetBool("playerNear", true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            turtleAnimator.SetBool("playerNear", false);
        }
    }
}
