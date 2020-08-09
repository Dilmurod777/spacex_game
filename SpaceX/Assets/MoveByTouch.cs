using System;
using System.Collections;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    private float force = 1.4f;
    private float rotationSpeed = 5f;
    float touchPointX;
    float touchPointY;
    private float _cameraSpeed = 10f;
    private float _cameraMinView = 71f;
    private float _cameraMaxView = 91f;
    private float maxVelocity = 15f;
    private float minVelocity = 5f;
    private float prevVelocity = 0;

    private Rigidbody2D _rb;
    private Camera _cam;
    private Touch _touch;

    private Coroutine _couroutine;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            StopAllCoroutines();
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

            if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
            {
                // move rocket
                _rb.AddForce(new Vector3(deltaX, deltaY, 0) * force);

                // increase/descrease camera due to velocity
                float velocity = _rb.velocity.magnitude;
                // limit the velocity
                if (velocity > maxVelocity)
                {
                    _rb.velocity = _rb.velocity.normalized * maxVelocity;
                }


                //float velocityRatio = (velocity - prevVelocity) / maxVelocity;
                //float cameraRatio = velocityRatio * (_cameraMaxView - _cameraMinView);
                //_cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView + cameraRatio, _cameraMinView, _cameraMaxView);
                if (velocity - prevVelocity > 1)
                {
                    // velocity increase -> larger camera view
                    _cam.fieldOfView += Time.fixedDeltaTime * _cameraSpeed;
                }
                else
                {
                    // velocity descrease -> smaller camera view
                    _cam.fieldOfView -= Time.fixedDeltaTime * _cameraSpeed;
                }
                _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView, _cameraMinView, _cameraMaxView);
                prevVelocity = velocity;

                // rotate to the touch point
                float angle = Vector3.SignedAngle(transform.up, new Vector3(deltaX, deltaY, transform.position.z).normalized, transform.forward);
                transform.Rotate(0, 0, angle * rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(ChangeCameraView(_cam.fieldOfView, _cameraMinView, 0.1f));
        }
    }

    IEnumerator ChangeCameraView(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            _cam.fieldOfView = Mathf.Lerp(v_start, v_end, Time.fixedDeltaTime);
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }
        _cam.fieldOfView = v_end;
    }
}
