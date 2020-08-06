using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidVisibility : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    PolygonCollider2D _polygonCollider;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        setVisibility(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerObjectDetector")
        {
            setVisibility(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerObjectDetector")
        {
            setVisibility(false);
        }
    }

    public void setVisibility(bool state)
    {
        _spriteRenderer.enabled = state;
        _polygonCollider.enabled = state;
    }
}
