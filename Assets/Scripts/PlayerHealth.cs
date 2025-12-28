using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int playerMaxLife;
    [SerializeField] private int playerCurrentLife;

    void Start()
    {
        playerCurrentLife = playerMaxLife;
    }

    void Update()
    {
        if (IsDead())
            gameObject.SetActive(false);
    }

    public void ReceiveDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 1);
        playerCurrentLife -= damageTaken;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            ReceiveDamage(50);
    }

    public bool IsDead()
    {
        if (playerCurrentLife > 0) return false;
        playerCurrentLife = 0;
        return true;
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
