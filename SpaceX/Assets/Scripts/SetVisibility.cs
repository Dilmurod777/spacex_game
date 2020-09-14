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
        if (gameObject.CompareTag("Asteroid"))
        {
            _collider = GetComponent<PolygonCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }
        else if (gameObject.CompareTag("Stars"))
        {
            _animator = GetComponent<Animator>();
            _autoRotate = GetComponent<AutoRotate>();

            _animator.enabled = false;
            _autoRotate.enabled = false;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (gameObject.CompareTag("Planets"))
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    
    public void setVisibility(bool state)
    {
        if (gameObject.CompareTag("Asteroid"))
        {
            _spriteRenderer.enabled = state;
            _collider.enabled = state;
        }
        else if (gameObject.CompareTag("Stars"))
        {
            _animator.enabled = state;
            _autoRotate.enabled = state;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
        else if (gameObject.CompareTag("Planets"))
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
    }
}