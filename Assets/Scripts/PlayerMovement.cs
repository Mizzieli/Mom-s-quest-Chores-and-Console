using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool isJumping;
    public bool isDucking;
    
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        //disable gravity
        _rb.gravityScale = 0;
        
        //initial position and rotation
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
        
        //enable gravity back
        _rb.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Ensures continuous movement to the right
        _rb.velocity = new Vector2(speed, _rb.velocity.y);

        //Jump function
        if (Input.GetButtonDown("Jump")&& !isJumping)
        {
            _rb.AddForce(Vector2.up * jump,ForceMode2D.Impulse);
            isJumping = true;
            Debug.Log("Jump");
        }
        
        // Duck function
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            Duck();
        }
        else if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
        {
            StandUp();
        }
        // Jump function
        if (Input.GetKey("w") || Input.GetKey("up"))
        { 
            Jump();
        }
        else if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
        {
            StandUp();
        }
    }

    void Duck()
    {
        isDucking = true;
    }
    void Jump()
    {
        _rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }
    
    //stand up function
    void StandUp()
    {
        isDucking = false;
    }
    
    //Collider2D component for ground detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = true;
        }
    }
}
