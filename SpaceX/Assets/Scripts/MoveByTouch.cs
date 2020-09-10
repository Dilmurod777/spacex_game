using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public static bool enableMoving = true;
    public GameObject angar;
    public GameObject hero;
    public GameObject heroRPrefab;
    public GameObject heroSeat;

    private const float Force = 1.1f;
    private const float RotationSpeed = 5f;
    private float _touchPointX;
    private float _touchPointY;
    private const float CameraSpeed = 5f;
    private const float CameraMinView = 65f;
    private const float CameraMaxView = 85f;
    private const float MAXVelocity = 15f;
    private float _prevVelocity = -1f;
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

        if (PlayerPrefs.HasKey("Uranus"))
        {
            var posX = PlayerPrefs.GetFloat("PositionX");
            var posY = PlayerPrefs.GetFloat("PositionY");
            var posZ = PlayerPrefs.GetFloat("PositionZ");
            var rotX = PlayerPrefs.GetFloat("RotationX");
            var rotY = PlayerPrefs.GetFloat("RotationY");
            var rotZ = PlayerPrefs.GetFloat("RotationZ");
            
            transform.position = new Vector3(posX, posY, posZ);
            transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
            PlayerPrefs.DeleteAll();
            
            // disable default hero
            hero.SetActive(false); 
            // place heroR
            var heroR = Instantiate(heroRPrefab, heroSeat.transform.position, quaternion.identity);
            heroR.transform.localScale = heroSeat.transform.localScale;
            heroR.transform.SetParent(transform);
        }
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

                    if (_prevVelocity > -1.0001f && _prevVelocity < -0.9999f)
                    {
                        _prevVelocity = velocity;
                    }
                    else
                    {
                        if (velocity - _prevVelocity > 0)
                        {
                            // increase field of view - go far
                            _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView + CameraSpeed * Time.fixedDeltaTime, CameraMinView, CameraMaxView);
                        }
                        else
                        {
                            // decrease field of view - come closer
                            _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView - CameraSpeed * Time.fixedDeltaTime,  CameraMinView, CameraMaxView);
                        }

                        _prevVelocity = velocity;
                    }

                    // rotate to the touch point
                    var rocketTransform = transform;
                    var angle = Vector3.SignedAngle(rocketTransform.up, new Vector3(deltaX, deltaY, rocketTransform.position.z).normalized,
                        rocketTransform.forward);
                    rocketTransform.Rotate(0, 0, angle * RotationSpeed * Time.fixedDeltaTime);
                }
            }
            else
            {
                // camera go to default field of view
                _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView - CameraSpeed * Time.fixedDeltaTime, CameraMinView, CameraMaxView);
                StopAllCoroutines();
            }
        }
    }
}