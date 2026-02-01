using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    // Private fields for encapsulation
    private float speed;
    private Vector2 direction;

    // Public properties for controlled access
    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Max(0, value); } // Ensure speed is non-negative
    }

    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value.normalized; } // Ensure direction is always normalized
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Initialize speed and direction
        Speed = 3f;
        Direction = new Vector2(1f, 1f); // Start with diagonal movement

        // Set the initial velocity
        rb.velocity = Direction * Speed;
    }

    void FixedUpdate()
    {
        // Track velocity every frame BEFORE the physics engine changes it
        lastVelocity = rb.velocity;

        // Update the Rigidbody's velocity based on the current speed and direction
        rb.velocity = Direction * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Use the velocity from the previous frame to calculate the reflection
        Speed = lastVelocity.magnitude; // Maintain the current speed
        Direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal); // Reflect direction

        // Apply the new velocity
        rb.velocity = Direction * Speed;
    }
}
