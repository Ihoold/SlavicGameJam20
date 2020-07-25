using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    public float shootingRange = 15f;

    Gun gun => GetComponentInChildren<Gun>();
    Rigidbody2D body => GetComponent<Rigidbody2D>();


    void Update()
    {
        // Shooting
        var rayDirection = player.transform.position - transform.position;
        var hit = Physics2D.Raycast(transform.position, rayDirection, shootingRange, LayerMask.GetMask("Level", "Player"));
        Debug.Log(hit.collider);
        if (hit.collider != null && hit.collider.tag == "Player") {
            // We can see player - look toward him
            body.rotation = Mathf.Atan2(rayDirection.y, rayDirection.x) * Mathf.Rad2Deg;
            // Shoot if not on cooldown
            if (gun.CanShoot()) gun.Shoot();
        }
    }
}
