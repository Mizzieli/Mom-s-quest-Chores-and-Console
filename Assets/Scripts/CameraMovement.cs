using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        //Move the camera with the player
        if (playerTransform !=null)
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position,targetPosition, cameraSpeed *Time.deltaTime);

        }
    }
}
