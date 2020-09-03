using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollRect;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.touches[0].position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        scrollRect.vertical = false;
        transform.position = Input.touches[0].position;
        _image.enabled = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        scrollRect.vertical = true;
        _image.sprite = null;
        _image.enabled = false;
    }
}
