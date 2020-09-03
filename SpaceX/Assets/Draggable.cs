using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IPointerExitHandler
{
    private Image _image;
    private ScrollRect _scrollRect;
    private bool _hoverOver;

    private void Start()
    {
        _hoverOver = true;
        _image = GetComponent<Image>();
        _scrollRect = FindObjectOfType<IceCreamScroll>().gameObject.GetComponent<ScrollRect>();
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

    public void OnPointerExit(PointerEventData eventData)
    {
        _scrollRect.vertical = false;
        _hoverOver = false;
        Destroy(gameObject);
    }
}