using System;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private float speed = 1.4f;
    private float rotationSpeed = 5f;
    float touchPointX;
    float touchPointY;
    private float _cameraTime = 1f;
    private float _cameraDefaultValue = 71f;
    private float _cameraUpperValue = 81f;
    private float _cameraLowerValue = 61f;
    private float _velocityUpperValue = 10f;
    private float _velocityLowerValue = 2f;

    private Rigidbody2D _rb;
    private Camera _cam;
    private Touch _touch;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            Vector3 touchPosInWorldSpace = _cam.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, _cam.farClipPlane));
            // move to the touch point
            touchPointX = touchPosInWorldSpace.x;
            touchPointY = touchPosInWorldSpace.y;

            float cameraHeight = 2f * _cam.orthographicSize;
            float cameraWidth = cameraHeight * _cam.aspect;
            float requiredHeight = 25;
            float requiredWidth = requiredHeight * _cam.aspect;
            float deltaX = touchPointX * requiredWidth / cameraWidth - transform.position.x;
            float deltaY = touchPointY * requiredHeight / cameraHeight - transform.position.y;

            if (_touch.phase == TouchPhase.Canceled || _touch.phase == TouchPhase.Stationary)
            {
                _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _cameraDefaultValue, Time.fixedDeltaTime * _cameraTime);
            }
            else if (_touch.phase == TouchPhase.Moved)
            {
                // move rocket
                _rb.AddForce(new Vector3(deltaX, deltaY, 0) * speed);

                // increase/descrease camera due to velocity
                float velocity = _rb.velocity.magnitude;
                Debug.Log(velocity);
                if (velocity > _velocityUpperValue)
                {
                    _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _cameraUpperValue, Time.fixedDeltaTime * _cameraTime);
                }
                else if (velocity < _velocityUpperValue && velocity > _velocityLowerValue)
                {
                    _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _cameraLowerValue, Time.fixedDeltaTime * _cameraTime);
                }
                else
                {
                    _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _cameraDefaultValue, Time.fixedDeltaTime * _cameraTime);
                }

                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(0, 0, angle * rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _cameraDefaultValue, Time.fixedDeltaTime * _cameraTime);
        }
    }
}
