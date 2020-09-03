using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Draggable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;
    private ScrollRect _scrollRect;
    private bool _hoverOver;

    private void Start()
    {
        _image = GetComponent<Image>();
        _scrollRect = FindObjectOfType<UI_InfiniteScroll>().gameObject.GetComponent<ScrollRect>();
    }

    private void FixedUpdate()
    {
        if (_hoverOver)
        {
            if (Input.touchCount > 0)
            {
                transform.position = Input.touches[0].position;
            }
        }
    }

    // public void OnDrag(PointerEventData eventData)
    // {
    //     transform.position = Input.touches[0].position;
    // }
    //
    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     _scrollRect.vertical = false;
    //     transform.position = Input.touches[0].position;
    //     _image.enabled = true;
    // }
    //
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     _scrollRect.vertical = true;
    //     _image.sprite = null;
    //     _image.enabled = false;
    //     Destroy(gameObject);
    // }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _hoverOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _scrollRect.vertical = false;
        _hoverOver = false;
        Destroy(gameObject);
    }
}