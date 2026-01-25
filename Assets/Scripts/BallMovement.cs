using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(3f, 3f);
    }

    void Update()
    {
        // Track velocity every frame BEFORE the physics engine changes it 
        // I can't believe this was the fix for it From my understanding originally how my code was written Unity was overwriting my script so it wouldn't change the numbers of the velocity at all
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Use the velocity from the previous frame to calculate the reflection
        float speed = lastVelocity.magnitude;
        Vector2 direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * speed;
    }
}
