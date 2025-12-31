using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int playerMaxLife;
    [SerializeField] private int playerCurrentLife;
    [SerializeField] private Animator playerHealthAnimator;

    void Start()
    {
        playerCurrentLife = playerMaxLife;
    }
    
    public void ReceiveDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 1);
        playerCurrentLife -= damageTaken;
        if (playerCurrentLife <= 0)
        {
            playerHealthAnimator.SetTrigger("PlayerDeathTrigger");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RockEnemyKills"))
            ReceiveDamage(100);
        if (collision.gameObject.CompareTag("SawTrap"))
            ReceiveDamage(50);
        if (collision.gameObject.CompareTag("FireTrap"))
            ReceiveDamage(20);
    }
    
    public int GetCurrentLife()
    {
        return playerCurrentLife;
    }

    public int GetMaxLife()
    {
        return playerMaxLife;
    }
}
