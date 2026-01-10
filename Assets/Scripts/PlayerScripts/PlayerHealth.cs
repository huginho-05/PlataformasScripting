using System;
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
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Traps
        if (collision.gameObject.CompareTag("RockEnemyKills"))
            ReceiveDamage(100);
        if (collision.gameObject.CompareTag("SawTrap"))
            ReceiveDamage(50);
        if (collision.gameObject.CompareTag("FireTrap"))
            ReceiveDamage(20);
        
        //Enemies
        if (collision.gameObject.CompareTag("TurtleEnemy"))
            ReceiveDamage(20);
        if (collision.gameObject.CompareTag("TrunkBullet"))
            ReceiveDamage(20);
        if (collision.gameObject.CompareTag("RinoEnemy"))
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
