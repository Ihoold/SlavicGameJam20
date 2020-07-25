using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpeed;
    public float shootingCooldown;
    public GameObject bulletPrefab;
    float afterCooldown = 0;

    public bool CanShoot() {
        return Time.time > afterCooldown;
    }

    public void Shoot() {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

        // Remove the bullet after some time (just in case)
        Object.Destroy(bullet, 10f);

        // Cooldown for firing with the gun
        SetCooldown();
    }

    public void SetCooldown() {
        afterCooldown = Time.time + shootingCooldown;
    }
}
