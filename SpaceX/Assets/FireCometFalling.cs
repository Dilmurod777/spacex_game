using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FireCometFalling : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _sprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _sprite.enabled = true;
        _animator.SetTrigger("startFalling");
        _animator.ResetTrigger("resetFalling");
    }

    public void resetCometFalling()
    {
        _sprite.enabled = false;
        _animator.SetTrigger("resetFalling");
        _animator.ResetTrigger("startFalling");
    }
}