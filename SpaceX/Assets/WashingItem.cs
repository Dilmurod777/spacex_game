using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WashingItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    private Camera _cam;
    private Vector3 _initialPosition;
    private bool _dragging;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (_dragging)
        {
            transform.localPosition = Input.touches[0].position;
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log(canvas.scaleFactor);
        // transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0) ;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragging = false;
    }
}