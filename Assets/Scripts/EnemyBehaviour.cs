using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float shootingRange = 15f;
    public float moveSpeed = 15f;
    public Transform[] patrol;
    public float actionCooldown = 1f;

    GameObject player => GameObject.FindWithTag("Player");
    Gun gun => GetComponentInChildren<Gun>();
    Rigidbody2D body => GetComponent<Rigidbody2D>();

    int patrolStep = 0;
    float nextMove = 0;

    void FixedUpdate()
    {
        // Shooting
        var rayDirection = player.transform.position - transform.position;
        var hit = Physics2D.Raycast(transform.position, rayDirection, shootingRange, LayerMask.GetMask("Level", "Player"));
        if (hit.collider != null && hit.collider.tag == "Player") {
            Debug.Log(body.transform);

            // We can see player - look toward him
            body.rotation = Mathf.Atan2(rayDirection.y, rayDirection.x) * Mathf.Rad2Deg;
            // Shoot if not on cooldown
            if (gun.CanShoot()) {
                            Debug.Log("shooting");
                SoundManagerScript.PlaySound("EnemyShoot");

                gun.Shoot();
            }
            // Cooldown so we don't go from shooting to patroling constantly
            nextMove = Time.time + actionCooldown;
            // Go back to the start of the patrol
            return;
        }

        // Moving
        if (Time.time > nextMove && patrol.Length > 0) {
            if (this.transform.position == patrol[patrolStep].position) {
                // We reached current goal, we need the next one
                patrolStep = (patrolStep + 1) % patrol.Length;
            }

            // Make sure we are facing toward our goal
            var lookDirection = patrol[patrolStep].position - transform.position;
            body.rotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // Move (we assume there are no obstacles)
            Vector2 newPosition = Vector2.MoveTowards(transform.position, patrol[patrolStep].position, Time.deltaTime * moveSpeed);
            body.position = newPosition;
        }
    }
}
