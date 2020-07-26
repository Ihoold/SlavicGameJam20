﻿using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float attraction = 50f;
    public float maxSpeed = 15f;
    public string gravityTag;
    public GameObject burstEffect;
    Rigidbody2D body => GetComponent<Rigidbody2D>();


    void OnCollisionEnter2D(Collision2D col) {
        if (col.otherCollider.tag == "EnemyBullet") {
            if (col.collider.tag == "Enemy") {
                Destroy(gameObject);
                return;
            }
        }

        // Explosion
        GameObject explosion = Instantiate(burstEffect, col.GetContact(0).point, transform.rotation);
        ParticleSystem parts = explosion.GetComponentInChildren<ParticleSystem>();

        // Object cleanup
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == gravityTag) {
            Vector2 direction = other.GetComponentInParent<Rigidbody2D>().position - body.position;
            body.AddForce(direction * attraction / (direction.magnitude * direction.magnitude));
        } 
    }

    void FixedUpdate ()
    {
        if(body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }
        // Rotate towards velocity
        body.rotation = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;
    }
}
