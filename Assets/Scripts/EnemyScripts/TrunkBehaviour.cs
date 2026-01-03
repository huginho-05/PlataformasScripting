using UnityEngine;

public class TrunkBehaviour : MonoBehaviour
{
    [SerializeField] private TrunkBullet bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    private float shootingRate = 1f;
    [SerializeField] private Vector2 directionBullet;
    private float timer;
    
    void Start()
    {
        timer = shootingRate;
    }

    void Update()
    {

        if (timer >= shootingRate)
        {
            Shoot();
        }
        
        timer += Time.deltaTime;
        
    }

    private void Shoot()
    {
        TrunkBullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        bullet.LaunchBullet(new Vector2(bulletSpawn.position.x, bulletSpawn.position.y) * directionBullet);
        timer = 0;
    }
}
