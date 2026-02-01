using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaddleController : MonoBehaviour
{
    public float speed = 5f; // Shared movement speed for all paddles
    protected Rigidbody2D rb; // Rigidbody2D reference for physics-based movement

    // Initialize the Rigidbody2D reference
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on " + gameObject.name);
        }
    }

    // Update the paddle's velocity based on input
    protected virtual void FixedUpdate()
    {
        float input = GetInput();
        Vector2 velocity = Vector2.up * input * speed;
        rb.velocity = velocity;
    }

    // Abstract method to get input, to be implemented by derived classes
    protected abstract float GetInput();
}
