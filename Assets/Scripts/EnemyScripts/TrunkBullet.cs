using UnityEngine;

public class TrunkBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private float destroyDelay = 1.5f;
    private Rigidbody2D bulletRb;


    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    public void LaunchBullet(Vector2 direction)
    {
        bulletRb.linearVelocity = direction * bulletSpeed;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
