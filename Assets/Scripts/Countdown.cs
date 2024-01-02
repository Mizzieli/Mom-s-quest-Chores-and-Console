using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;
    bool bulletWarningShown = true;
    float bulletWarningThreshold = 3f;

    public AutomaticWeapon automaticWeapon;
    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        countdownText.text = startingTime.ToString();
        if (automaticWeapon == null)
        {
            Debug.LogError("AutomaticWeapon not assigned. Make sure to assign it in the Inspector.");
        }

        automaticWeapon.OnShotFired += HandleShotFired;
    }

    private void Update()
    {
        currentTime = Mathf.Max(0, currentTime - Time.deltaTime);
        countdownText.text = Mathf.Ceil(currentTime).ToString("0");

        if (currentTime <= bulletWarningThreshold && !bulletWarningShown)
        {
            Debug.Log("Warning: Bullet will be shot soon!");
            bulletWarningShown = true;
            automaticWeapon.NotifyBulletWarning();
        }
    }

    private void HandleShotFired()
    {
        // Handle shot fired event
    }
}