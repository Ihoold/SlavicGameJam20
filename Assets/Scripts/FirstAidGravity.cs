using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidGravity : MonoBehaviour
{    
    public float attraction = 15f;
    Rigidbody2D body => GetComponentInParent<Rigidbody2D>();

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            Vector2 direction = other.GetComponent<Rigidbody2D>().position - body.position;
            body.AddForce(direction * attraction / (direction.magnitude * direction.magnitude));
        }
    }
}
