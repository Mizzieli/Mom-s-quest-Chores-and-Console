using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothercontroller : MonoBehaviour
{
    public Transform target; // Set this to the "PlayerMain" transform in the Inspector
    public float moveSpeed = 5f;
    public GameObject motherControllerObject;
    void Start()
    {
        // Disable the mothercontroller initially
        if (motherControllerObject != null)
        {
            motherControllerObject.SetActive(false);
        }
    }

    void SomeConditionMet()
    {
        // Enable or disable the mothercontroller based on your condition
        if (motherControllerObject != null)
        {
            motherControllerObject.SetActive(true); // or false based on your condition
        }
    }
}
