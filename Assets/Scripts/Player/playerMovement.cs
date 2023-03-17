using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kilde: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float walkSpeed;
    public float runSpeed;
    float speed;

    void Start()
    {
        speed = walkSpeed;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down


        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = runSpeed;
            
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = walkSpeed;
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
