using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float rotationY;
    public Rigidbody2D rb;
    Vector2 movement;

     void OnTriggerEnter2D(Collider2D collision) 
     {
        // When a collision is detected on the enemy, speed gets multiplied by -1, so the enemy moves the opposite direction.
        moveSpeed *= -1f;
        
        // Also the enemy sprite will be rotated by adding 180 to the ratation Y axis if the current rotation is 0.
        if (rotationY == 0f) {
            rotationY += 180f;
        }
        // If the sprite is already turned 180, the sprite will then turn again by subtracting 180 making it 0 again.
        else if (rotationY == 180f) {
            rotationY -= 180f;
        }
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    void Update() 
    {
        movement.x = 1f;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
