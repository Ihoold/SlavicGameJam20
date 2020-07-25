using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float attraction = 50f;
    public float maxSpeed = 15f;
    public string gravityTag;
    Rigidbody2D body => GetComponent<Rigidbody2D>();


    void OnCollisionEnter2D(Collision2D col) {
        // Special effects, damaging enemies
        if (col.gameObject.tag == "Enemy") {
            Debug.Log("Hit!");
        }

        Debug.Log(col.collider.tag);
        
        Destroy(this.gameObject);
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
    }
}
