using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    // Assuming these are the necessary references
    public float distanceTravelled;
    public float bulletSpeed;
    public float shootDistance;
    public float cooldownTime;
    public System.Action OnShotFired;

    void Update()
    {
        distanceTravelled += bulletSpeed * Time.deltaTime;
        countdownText.text = Mathf.Ceil(cooldownTime).ToString();

        if (distanceTravelled >= shootDistance && Time.time - lastShootTime >= cooldownTime)
        {
            Shoot();
            lastShootTime = Time.time;
            distanceTravelled = 0.0f;
            OnShotFired?.Invoke();
        }
    }

    // Assuming these are the necessary references
    public TextMeshProUGUI countdownText;
    private float lastShootTime;

    public void StartGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("Game started!");
            SceneManager.LoadScene(1);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
        // Add any game over logic or transitions here
    }

    // Assuming these are the necessary references
    private void Shoot()
    {
        // Implement the shooting logic here
    }
}