using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidWrapperPosition : MonoBehaviour
{
    Transform _asteroid;
    CircleCollider2D _collider;
    private void Start()
    {
        _asteroid = transform.GetChild(0).transform;
        _collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        _collider.offset = new Vector2(_asteroid.localPosition.x, _asteroid.localPosition.y);
    }
}
