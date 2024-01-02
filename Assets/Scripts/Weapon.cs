using System;
using System.Collections;
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
    private float lastShootTime;
    public TextMeshProUGUI countdownText;

    public event Action OnShotFired;

    private void Start()
    {
        countdownText.text = cooldownTime.ToString();
    }

    private void Update()
    {
        distanceTravelled += bulletSpeed * Time.deltaTime; // Track distance based on bullet speed

        countdownText.text = Mathf.Ceil(cooldownTime).ToString();

        if (distanceTravelled >= shootDistance && Time.time - lastShootTime >= cooldownTime)
        {
            Shoot();
            lastShootTime = Time.time;
            distanceTravelled = 0.0f;
            OnShotFired?.Invoke();
        }
    }

    private void Shoot()
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

    public void NotifyBulletWarning()
    {
        Debug.Log("Warning: Bullet will be shot soon!");
    }
}