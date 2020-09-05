using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    private GameObject _player;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private AutoRotate _autoRotate;

    // Start is called before the first frame update
    private void Start()
    {
        //setVisibility(false);
        _player = FindObjectOfType<Player>().gameObject;
        if (gameObject.tag == "Asteroid")
        {
            _collider = GetComponent<PolygonCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        else if (gameObject.tag == "Stars")
        {
            _animator = GetComponent<Animator>();
            _autoRotate = GetComponent<AutoRotate>();
            _collider = GetComponent<CircleCollider2D>();
        }
        else if (gameObject.tag == "Planets")
        {
            _collider = GetComponent<CircleCollider2D>();
        }
    }

    private void FixedUpdate()
    {
        if (MoveByTouch.enableMoving)
        {
            float distance = (_player.transform.position - transform.position).magnitude;

            if (distance < 30)
            {
                setVisibility(true);
            }
            else
            {
                setVisibility(false);
            }
        }
    }

    public void setVisibility(bool state)
    {
        if (gameObject.tag == "Asteroid")
        {
            _spriteRenderer.enabled = state;
            _collider.enabled = state;
        }
        else if (gameObject.tag == "Stars")
        {
            _animator.enabled = state;
            _autoRotate.enabled = state;
            _collider.enabled = state;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
        else if (gameObject.tag == "Planets")
        {
            _collider.enabled = state;

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
    }

}
