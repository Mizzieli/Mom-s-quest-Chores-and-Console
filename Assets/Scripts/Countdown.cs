using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;

    [SerializeField] TextMeshProUGUI countdownText;

    bool bulletWarningShown = true;
    float bulletWarningThreshold = 3f;

    private AutomaticWeapon automaticWeapon;

    void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("CountdownText not assigned. Make sure to assign it in the Inspector.");
        }

        currentTime = startingTime;

        // Find the AutomaticWeapon script
        automaticWeapon = FindObjectOfType<AutomaticWeapon>();
        if (automaticWeapon == null)
        {
            Debug.LogError("AutomaticWeapon script not found.");
        }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText.gameObject.SetActive(false);

            // Notify the AutomaticWeapon about the shot
            automaticWeapon.NotifyShot();
        }
        else
        {
            // Update the text
            countdownText.text = Mathf.Ceil(currentTime).ToString("0");
        }

        // Show a warning when countdown reaches the threshold
        if (currentTime <= bulletWarningThreshold && !bulletWarningShown)
        {
            Debug.Log("Warning: Bullet will be shot soon!");
            bulletWarningShown = true;

            // Notify the AutomaticWeapon about the warning
            automaticWeapon.NotifyBulletWarning();
        }
    }
}