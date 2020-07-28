using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private float speed = 125f;
    private float rotationSpeed = 10f;
    float touchPointX;
    float touchPointY;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector3 touchPosInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane));
                // move to the touch point
                touchPointX = touchPosInWorldSpace.x;
                touchPointY = touchPosInWorldSpace.y;

                float cameraHeight = 2f * Camera.main.orthographicSize;
                float cameraWidth = cameraHeight * Camera.main.aspect;
                float requiredHeight = 20;
                float requiredWidth = requiredHeight * Camera.main.aspect;
                float deltaX = touchPointX * requiredWidth / cameraWidth;
                float deltaY = touchPointY * requiredHeight / cameraHeight;

                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(deltaX, deltaY).normalized * speed);

                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(0, 0, angle * rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
