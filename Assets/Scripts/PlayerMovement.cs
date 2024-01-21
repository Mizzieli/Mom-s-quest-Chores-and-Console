using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce=5000f;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    public Transform groundCheck;

    private bool _isJumping;
    private bool _isDucking;
    private bool canMove = false;  // Added flag to control player movement
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator _anim;
    private float originalColliderHeight;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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


    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // Subscribe to the event when the game state changes to Playing
            gameManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
        }

        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // Set gravity scale in the Unity inspector for Rigidbody2D component
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            originalColliderHeight = collider.size.y;
        }
    }
    
    void Update()
    {
        
        if (!canMove)
        {
            // If canMove is false, make the player stand
            StandUp();
            return;
        }

        // Duck function
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Duck();
        }
        else
        {
            StandUp();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        
        audioManager.PlaySFX(audioManager.jump);
    }
    
    void Duck()
    {
        if (isJumping)
        {
            return;
        }

        isDucking = true;
        
        //adjusting the players collider or animation for ducking
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.size = new Vector2(collider.size.x, originalColliderHeight * 0.5f);
        }
    }
    // Stand up function
    void StandUp()
    {
        isDucking = false;
        //Restore the original collider height when standing up
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.size = new Vector2(collider.size.x, originalColliderHeight);
        }
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
        
        else if (newState == GameManager.GameState.GameOver)
        {
            canMove = false;  // Prevent player movement
            // Play game over sound
            audioManager.PlayGameOver();
        }

    }
}
