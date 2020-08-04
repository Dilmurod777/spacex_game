﻿using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private float speed = 1.2f;
    private float rotationSpeed = 5f;
    float touchPointX;
    float touchPointY;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Camera cam = Camera.main;
            Vector3 touchPosInWorldSpace = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.farClipPlane));
            // move to the touch point
            touchPointX = touchPosInWorldSpace.x;
            touchPointY = touchPosInWorldSpace.y;

            float cameraHeight = 2f * cam.orthographicSize;
            float cameraWidth = cameraHeight * cam.aspect;
            float requiredHeight = 25;
            float requiredWidth = requiredHeight * cam.aspect;
            float deltaX = touchPointX * requiredWidth / cameraWidth - transform.position.x;
            float deltaY = touchPointY * requiredHeight / cameraHeight - transform.position.y;

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(0, 0, angle * rotationSpeed * Time.fixedDeltaTime);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // move rocket
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(deltaX, deltaY, 0) * speed);
                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(0, 0, angle * rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
