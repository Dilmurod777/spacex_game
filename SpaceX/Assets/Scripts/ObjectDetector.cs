using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    private Camera _cam;
    private BoxCollider2D _collider;
    private Vector2 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _collider = GetComponent<BoxCollider2D>();


        var height = _cam.orthographicSize * 2f;
        var width = height * _cam.aspect;
        _offset = new Vector2(0f, 0f);
        _collider.size = new Vector2(width + _offset.x, height + _offset.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        other.GetComponent<SetVisibility>().setVisibility(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<SetVisibility>().setVisibility(false);
    }
}