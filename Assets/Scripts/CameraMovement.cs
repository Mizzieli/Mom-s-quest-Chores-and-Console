using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float initialCameraSpeed = 5.0f;
    public float maxCameraSpeed = 20.0f;
    public float speedIncrementRate = 0.1f;

    private float currentCameraSpeed;

    // Reference to the GameManager script
    public GameManager gameManager;

    // Variable to track if the game has started
    private bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the game has started
        if (gameStarted)
        {
            // Gradually increase the camera speed
            currentCameraSpeed = Mathf.Min(currentCameraSpeed + speedIncrementRate * Time.deltaTime, maxCameraSpeed);

            // Move the camera
            transform.position += new Vector3(currentCameraSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            // Check for arrow key press to start the game
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Notify the GameManager to start the game
                gameManager.StartGame();
                // Set gameStarted to true
                gameStarted = true;

                // Set the initial camera speed
                currentCameraSpeed = initialCameraSpeed;
            }
        }
    }
}