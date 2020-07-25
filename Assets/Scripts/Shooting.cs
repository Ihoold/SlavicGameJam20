using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform gun;
    public GameObject bulletPrefab;
    public float bulletSpeed = 1.5f;
    public float cooldown = 1f;

    float afterCooldown = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > afterCooldown) {
            // Shoot
            var bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
            var bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(gun.right * bulletSpeed, ForceMode2D.Impulse);

            // Remove the bullet after some time (just in case)
            Object.Destroy(bullet, 10f);

            // Cooldown for firing with the gun
            afterCooldown = Time.time + cooldown;
        }
    }
}
