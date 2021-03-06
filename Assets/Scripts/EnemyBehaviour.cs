﻿using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float shootingRange = 15f;
    public float moveSpeed = 15f;
    public Transform[] patrol;
    public float actionCooldown = 1f;
    public float shotCooldown = 0.1f;

    GameObject player => GameObject.FindWithTag("Player");
    Gun gun => GetComponentInChildren<Gun>();
    Rigidbody2D body => GetComponent<Rigidbody2D>();

    int patrolStep = 0;
    float nextMove = 0;

    // Wait at least one frame before shooting
    public float playerNotSpotted = 0;

    void FixedUpdate()
    {
        // Shooting
        var rayDirection = player.transform.position - transform.position;
        var hit = Physics2D.Raycast(transform.position, rayDirection, shootingRange, LayerMask.GetMask("Level", "Player"));
        if (hit.collider != null && hit.collider.tag == "Player" && (transform.position - hit.collider.gameObject.transform.position).magnitude <= shootingRange) {
            // We can see player - look toward him
            body.rotation = Mathf.Atan2(rayDirection.y, rayDirection.x) * Mathf.Rad2Deg;
            // Shoot if not on cooldown and if we have seen player for at least shotCooldown seconds
            if (gun.CanShoot() && (playerNotSpotted <= Time.time - shotCooldown)) {
                SoundManagerScript.PlaySound("EnemyShoot");
                gun.Shoot();
            }
            // Cooldown so we don't go from shooting to patroling constantly
            nextMove = Time.time + actionCooldown;
            // Go back to the start of the patrol
            return;
        }

        playerNotSpotted = Time.time;
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
