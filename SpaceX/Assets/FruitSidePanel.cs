using System;
using UnityEngine;

public class FruitSidePanel : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void MoveAside()
    {
        _animator.SetBool("move_aside", true);
    }
    
    public void MoveBack()
    {
        _animator.SetBool("move_aside", false);
    }
}
