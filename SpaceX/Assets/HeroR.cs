using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroR : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ResetDrinkTrigger()
    {
        _animator.ResetTrigger("drink");
    }
}
