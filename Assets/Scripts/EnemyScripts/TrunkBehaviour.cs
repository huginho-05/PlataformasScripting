using UnityEngine;

public class TrunkBehaviour : MonoBehaviour
{
    [SerializeField] private Animator trunkAnimator;
    [SerializeField] private TrunkBullet bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float shootingRate;
    [SerializeField] private Vector2 directionBullet;
    private float timer;
    
    void Start()
    {
        timer += Time.deltaTime;
    }

    void Update()
    {

        if (timer >= shootingRate)
        {
            TrunkBullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            bullet.LaunchBullet(new Vector2(bulletSpawn.position.x, bulletSpawn.position.y) * directionBullet);
            timer = 0;
        }
        
        timer += Time.deltaTime;
        
    }
}
