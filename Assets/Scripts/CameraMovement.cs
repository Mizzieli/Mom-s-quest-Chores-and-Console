using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float initialCameraSpeed = 5.0f;
    public float maxCameraSpeed = 20.0f;
    public float speedIncrementRate = 0.1f;

    private float currentCameraSpeed;
    private bool gameStarted = false;

    public AutomaticWeapon weapon;
    public GameManager gameManager;

    void Update()
    {
        if (gameStarted)
        {
            currentCameraSpeed = Mathf.Min(currentCameraSpeed + speedIncrementRate * Time.deltaTime, maxCameraSpeed);
            transform.position += new Vector3(currentCameraSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameManager.StartGame();
            gameStarted = true;
            currentCameraSpeed = initialCameraSpeed;
            weapon.OnShotFired += OnWeaponShot;
        }
    }

    void OnWeaponShot()
    {
        currentCameraSpeed = Mathf.Min(currentCameraSpeed + speedIncrementRate, maxCameraSpeed);
    }
}