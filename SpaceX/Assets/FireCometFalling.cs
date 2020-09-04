using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FireCometFalling : MonoBehaviour
{
    private Animator _animator;
    private bool _triggered;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_triggered)
        {
            _animator.SetTrigger("startFalling");
            _animator.ResetTrigger("resetFalling");
            _triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_triggered)
        {
            _animator.SetTrigger("resetFalling");
            _animator.ResetTrigger("startFalling");
            _triggered = false;
        }
    }
}