﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Camera Follow")]
public class CameraFollow : MonoBehaviour
{
	//Bound camera to limits
    public bool limitBounds = false;
    public float left = -5f;
    public float right = 5f;
    public float bottom = -5f;
    public float top = 5f;

    private Transform _target;
	private Vector3 _lerpedPosition;

    private Camera _camera;

    private void Awake()
    {
	    _target = FindObjectOfType<Player>().transform;
	    
        _camera = GetComponent<Camera>();
        if (PlayerPrefs.GetString("playedMiniGame").Equals("true"))
        {
	        var position = _camera.transform.position;
	        position.x = PlayerPrefs.GetFloat("positionX");
	        position.y = PlayerPrefs.GetFloat("positionY");

	        _camera.transform.position = position;
        }
        else
        {
	        _camera.transform.position = _target.position;
        }
    }

    // FixedUpdate is called every frame, when the physics are calculated
    void FixedUpdate()
	{
		if(_target != null)
		{
			// Find the right position between the camera and the object
			_lerpedPosition = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * 10f);
			_lerpedPosition.z = -10f;
		}
	}



	// LateUpdate is called after all other objects have moved
	void LateUpdate ()
	{
		if(_target != null)
		{
			// Move the camera in the position found previously
			transform.position = _lerpedPosition;

            // Bounds the camera to the limits (if enabled)
            if(limitBounds) {
                Vector3 bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
                Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
                Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

                Vector3 boundPosition = transform.position;
                if (boundPosition.x > right - (screenSize.x / 2f)) {
                    boundPosition.x = right - (screenSize.x / 2f);
                }
                if (boundPosition.x < left + (screenSize.x / 2f)) {
                    boundPosition.x = left + (screenSize.x / 2f);
                }

                if (boundPosition.y > top - (screenSize.y / 2f)) {
                    boundPosition.y = top - (screenSize.y / 2f);
                }
                if (boundPosition.y < bottom + (screenSize.y / 2f)) {
                    boundPosition.y = bottom + (screenSize.y / 2f);
                }
                transform.position = boundPosition;
            }
		}
	}
}
