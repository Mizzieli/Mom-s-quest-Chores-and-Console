using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private float movementSpeed = 0.0f;
    private bool _isJumping;
    private bool _isDucking;
    private bool _isSpeeding;

    private Rigidbody2D _rb;
    private Animator _anim;

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

    public bool isSpeeding
    {
        get
        {
            return _isSpeeding;
        }
        set
        {
            _isSpeeding = value;
            _anim.SetBool("Speeding", _isSpeeding);
        }
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        // Set gravity scale in the Unity inspector for Rigidbody2D component
    }

    void Update()
    {
        // Ensures continuous movement to the right
        _rb.velocity = new Vector2(speed, _rb.velocity.y);

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
            // Already jumping or ducking - no need to continue
            return;
        }
        _rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
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
}
