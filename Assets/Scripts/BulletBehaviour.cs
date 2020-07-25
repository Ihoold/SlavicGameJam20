using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float attraction = 50f;
    Rigidbody2D body => GetComponent<Rigidbody2D>();


    void OnCollisionEnter2D(Collision2D col) {
        // Special effects, damaging enemies
        if (col.gameObject.tag == "Enemy") {
            Debug.Log("Hit!");
        }

        Destroy(this.gameObject);
    }



    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Enemy Gravity") {
            Vector2 direction = other.GetComponentInParent<Rigidbody2D>().position - body.position;
            body.AddForce(direction * attraction / (direction.magnitude * direction.magnitude));
        } 
    }
}
