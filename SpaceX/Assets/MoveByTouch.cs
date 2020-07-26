using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 pointA;
    private Vector2 pointB;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pointA = transform.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = Vector3.ClampMagnitude(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z)) - transform.position, 1.0f);
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}
