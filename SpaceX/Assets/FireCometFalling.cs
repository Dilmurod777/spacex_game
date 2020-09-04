using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FireCometFalling : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>().gameObject;
    }

    private void FixedUpdate()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetTrigger("startFalling");
        Debug.Log("COMET TRIGGER ENTER " + name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _animator.SetTrigger("resetFalling");
        Debug.Log("COMET TRIGGER EXIT | " + name);
    }
}
