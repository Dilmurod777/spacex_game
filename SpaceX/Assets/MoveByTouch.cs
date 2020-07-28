using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private float speed = 15f;
    private float acceleration = 25f;
    private float rotationSpeed = 15f;


    private void Update()
    {
        //transform.Translate(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // move to the touch point
                float touchPointX = Camera.main.ScreenToWorldPoint(touch.position).x;
                float touchPointY = Camera.main.ScreenToWorldPoint(touch.position).y;
                float deltaX = touchPointX - transform.position.x;
                float deltaY = touchPointY - transform.position.y;
                //velocity.x = Mathf.Clamp(Mathf.MoveTowards(velocity.x, speed * deltaX, acceleration * Time.fixedDeltaTime), -speed, speed);
                //velocity.y = Mathf.Clamp(Mathf.MoveTowards(velocity.y, speed * deltaY, acceleration * Time.fixedDeltaTime), -speed, speed);
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(deltaX, deltaY) * speed);


                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(Vector3.forward, angle * rotationSpeed * Time.fixedDeltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, acceleration * Time.deltaTime);
                velocity.y = Mathf.MoveTowards(velocity.y, 0, acceleration * Time.deltaTime);
            }
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, acceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, 0, acceleration * Time.deltaTime);
        }
    }
}
