using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        // Check for arrow key press to start the game
        if (gameStarted || (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow)))
        {
            return;
        }

        StartGame();
    }

    // Method to start the game
    public void StartGame()
    {
        Debug.Log("Game started!");
        gameStarted = true; // Set gameStarted to true to prevent multiple starts
        // Add any additional initialization logic here
    }

    // Method to handle game over conditions
    public void GameOver()
    {
        Debug.Log("Game over!");
        // Add any game over logic or transitions here
    }
}