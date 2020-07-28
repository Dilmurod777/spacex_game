using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private float speed = 100f;
    private float rotationSpeed = 15f;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // move to the touch point
                float touchPointX = Camera.main.ScreenToWorldPoint(touch.position).x;
                float touchPointY = Camera.main.ScreenToWorldPoint(touch.position).y;
                float deltaX = touchPointX - transform.position.x;
                float deltaY = touchPointY - transform.position.y;

                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(deltaX, deltaY).normalized * speed);

                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(Vector3.forward, angle * rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
