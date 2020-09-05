using System.Collections;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public static bool enableMoving = true;
    public GameObject angar;

    private const float Force = 1.1f;
    private const float RotationSpeed = 5f;
    private float _touchPointX;
    private float _touchPointY;
    private const float CameraSpeed = 10f;
    private const float CameraMinView = 71f;
    private const float CameraMaxView = 91f;
    private const float MAXVelocity = 15f;
    private float _prevVelocity;
    private Rigidbody2D _rb;
    private Camera _cam;
    private Touch _touch;
    private Animator _angarAnimator;
    private bool _isAngarClosed = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        _angarAnimator = angar.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (enableMoving)
        {
            if (Input.touchCount > 0)
            {
                if (!_isAngarClosed)
                {
                    _angarAnimator.SetTrigger("close");
                    _isAngarClosed = true;
                }
                
                StopAllCoroutines();
                _touch = Input.GetTouch(0);
                var touchPosInWorldSpace = _cam.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, _cam.farClipPlane));
                // move to the touch point
                _touchPointX = touchPosInWorldSpace.x;
                _touchPointY = touchPosInWorldSpace.y;

                var cameraHeight = 2f * _cam.orthographicSize;
                var aspect = _cam.aspect;
                var cameraWidth = cameraHeight * aspect;
                const int requiredHeight = 25;
                var requiredWidth = requiredHeight * aspect;
                var position = transform.position;
                var deltaX = _touchPointX * requiredWidth / cameraWidth - position.x;
                var deltaY = _touchPointY * requiredHeight / cameraHeight - position.y;

                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
                {
                    // move rocket
                    _rb.AddForce(new Vector3(deltaX, deltaY, 0) * Force);

                    // increase/decrease camera due to velocity
                    var velocity = _rb.velocity.magnitude;
                    // limit the velocity
                    if (velocity > MAXVelocity)
                    {
                        _rb.velocity = _rb.velocity.normalized * MAXVelocity;
                    }


                    //float velocityRatio = (velocity - prevVelocity) / maxVelocity;
                    //float cameraRatio = velocityRatio * (_cameraMaxView - _cameraMinView);
                    //_cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView + cameraRatio, _cameraMinView, _cameraMaxView);
                    if (velocity - _prevVelocity > 1)
                    {
                        // velocity increase -> larger camera view
                        _cam.fieldOfView += Time.fixedDeltaTime * CameraSpeed;
                    }
                    else
                    {
                        // velocity decrease -> smaller camera view
                        _cam.fieldOfView -= Time.fixedDeltaTime * CameraSpeed;
                    }

                    _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView, CameraMinView, CameraMaxView);
                    _prevVelocity = velocity;

                    // rotate to the touch point
                    var rocketTransform = transform;
                    var angle = Vector3.SignedAngle(rocketTransform.up, new Vector3(deltaX, deltaY, rocketTransform.position.z).normalized,
                        rocketTransform.forward);
                    rocketTransform.Rotate(0, 0, angle * RotationSpeed * Time.fixedDeltaTime);
                }
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(ChangeCameraView(_cam.fieldOfView, CameraMinView, 0.1f));
            }
        }
    }

    private IEnumerator ChangeCameraView(float vStart, float vEnd, float duration)
    {
        var elapsed = 0.0f;
        while (elapsed < duration)
        {
            _cam.fieldOfView = Mathf.Lerp(vStart, vEnd, Time.fixedDeltaTime);
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }

        _cam.fieldOfView = vEnd;
    }
}