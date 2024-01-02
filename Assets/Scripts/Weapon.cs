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
    public float cooldownTime = 30.0f;

    private float distanceTravelled = 0.0f;
    private Vector3 lastPosition;
    private float lastShootTime;

    public TextMeshProUGUI countdownText;
    private float countdownTimer;

    private void Start()
    {
        countdownTimer = cooldownTime;
    }

    private void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        if (distanceTravelled >= shootDistance)
        {
            if (Time.time - lastShootTime >= cooldownTime)
            {
                Shoot();
                distanceTravelled = 0.0f;
                lastShootTime = Time.time;
                countdownTimer = cooldownTime;
            }
            else
            {
                countdownTimer -= Time.deltaTime;
            }
        }
        else
        {
            countdownTimer = cooldownTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = firePoint.right * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab is missing Rigidbody2D component.");
        }
    }

    // Method to notify CountdownTimer about the shot
    public void NotifyShot()
    {
        Debug.Log("Shot detected");
    }

    // Method to notify CountdownTimer about the warning
    public void NotifyBulletWarning()
    {
        Debug.Log("Bullet warning detected");
    }
}
