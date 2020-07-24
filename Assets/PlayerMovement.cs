using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 30;
    Rigidbody2D body => GetComponent<Rigidbody2D>();
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate() 
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
