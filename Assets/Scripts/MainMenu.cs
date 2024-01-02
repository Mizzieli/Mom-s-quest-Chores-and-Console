using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        // Check for arrow key press to start the game
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameManager.StartGame();
        }
    }

    public void PlayGame()
    {
        Debug.Log("Play button clicked! Waiting for arrow key press to start.");
        // Optionally, you can provide some visual feedback or instructions to the player.
    }
}