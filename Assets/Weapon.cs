using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutomaticWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float shootDistance = 20.0f;
    public float cooldownTime = 30.0f; // Increased cooldown time

    private float distanceTravelled = 0.0f;
    private Vector3 lastPosition;
    private float lastShootTime;

    public TextMeshProUGUI countdownText; // Reference to the TMP Text element
    private float countdownTimer; // Countdown timer value

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = cooldownTime; // Initialize the countdown timer
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance travelled
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        // Update the TMP Text with the countdown timer
        countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        // Check if the distance travelled is greater than or equal to shootDistance
        if (distanceTravelled >= shootDistance)
        {
            // Check if enough time has passed since the last shot
            if (Time.time - lastShootTime >= cooldownTime)
            {
                // Shoot automatically
                Shoot();

                // Reset the distance travelled
                distanceTravelled = 0.0f;
                // Record the time of the last shot
                lastShootTime = Time.time;

                // Reset the countdown timer
                countdownTimer = cooldownTime;
            }
            else
            {
                // Update the countdown timer
                countdownTimer -= Time.deltaTime;
            }
        }
        else
        {
            // Reset the countdown timer when not shooting
            countdownTimer = cooldownTime;
        }
    }

    void Shoot()
    {
        // Instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Access the Rigidbody component of the bullet
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Check if the bullet has a Rigidbody2D component
        if (bulletRb != null)
        {
            // Set the velocity of the bullet to achieve the desired speed
            bulletRb.velocity = firePoint.right * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab is missing Rigidbody2D component.");
        }
    }
}
