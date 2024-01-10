using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private bool _isJumping;
    private bool _isDucking;
    private bool canMove = false;  // Added flag to control player movement

    public bool isJumping
    {
        get
        {
            return _isJumping;
        }
        set
        {
            _isJumping = value;
            _anim.SetBool("Jumping", _isJumping);
        }
    }

    public bool isDucking
    {
        get
        {
            return _isDucking;
        }
        set
        {
            _isDucking = value;
            _anim.SetBool("Ducking", _isDucking);
        }
    }
    
    private Rigidbody2D _rb;
    private Animator _anim;

    void Start()
    {
        // Assuming you have a reference to the GameManager instance
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // Subscribe to the event when the game state changes to Playing
            gameManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
        }

        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        // Set gravity scale in the Unity inspector for Rigidbody2D component
    }

    void Update()
    {
        if (_anim != null && _rb != null)
        {
            if (!canMove)
            {
                // If canMove is false, make the player stand
                StandUp();
                return;
            }
        } 

        if (!canMove)
        {
            // If canMove is false, make the player stand
            StandUp();
            return;
        }

        // Jump function
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            Jump();
        }

        // Duck function
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            Duck();
        }
        else
        {
            StandUp();
        }

        // Movement function
        Move();
    }

    void Move()
    {
        // If no movement keys are pressed, set horizontal velocity to 0
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * speed, _rb.velocity.y);
    }

    void Duck()
    { 
        if (isJumping)
        {
            return;
        }
        
        isDucking = true;
    }

    void Jump()
    {
        if (isJumping || isDucking)
        {
            return;
        }

        // Apply impulse for jumping
        _rb.velocity = new Vector2(_rb.velocity.x, 2);  // Zero out the vertical velocity before jumping
        _rb.AddForce(_rb.velocity);
    }

    // Stand up function
    void StandUp()
    {
        isDucking = false;
    }

    // Collider2D component for ground detection
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

    void HandleGameStateChanged(GameManager.GameState newState)
    {
        // Check if the game state is set to Playing
        if (newState == GameManager.GameState.Playing)
        {
            canMove = true;  // Allow player movement
        }
    }
}
