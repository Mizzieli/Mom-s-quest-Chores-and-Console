using UnityEngine;

public class mothercontroller : MonoBehaviour
{
    public float speed =5f;
    public Transform target;
    
    private bool _isRunning;
    private bool _isIncreasingInSpeed;

    private Animator _anim;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the target (PlayerMain) is set
        if (target != null)
        {
            Debug.Log("Chaser moving towards target");
            // Move towards the target
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Target not set!");
        }
    }
}