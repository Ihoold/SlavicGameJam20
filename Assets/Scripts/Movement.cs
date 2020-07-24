using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 10;
    Rigidbody2D body => GetComponent<Rigidbody2D>();
    
    Vector2 movement;
    Vector2 aim;

    void Update()
    {
        // Movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Aiming
        aim = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() 
    {
        // Movement
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Aiming
        Vector2 look = aim - body.position;
        body.rotation = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
    }
}
