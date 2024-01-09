using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;

    private bool scrollingStarted = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar is pressed to start scrolling
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scrollingStarted = true;
        }

        // Continue scrolling only if the space bar has been pressed
        if (scrollingStarted)
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
        }
    }
}