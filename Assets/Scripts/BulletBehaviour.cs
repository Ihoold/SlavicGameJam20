using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float attraction = 50f;
    public float maxSpeed = 15f;
    public string gravityTag;
    public GameObject burstEffect;
    Rigidbody2D body => GetComponent<Rigidbody2D>();


    void OnCollisionEnter2D(Collision2D col) {
        // Explosion
        GameObject explosion = Instantiate(burstEffect, transform.position, transform.rotation);
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
