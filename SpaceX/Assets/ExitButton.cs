using System;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public static bool appear = false;
    
    private Animator _animator;
    private static readonly int Disappear = Animator.StringToHash("disappear");
    private static readonly int Appear = Animator.StringToHash("appear");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (appear)
        {
            _animator.SetTrigger(Appear);
        }
    }

    public void ResetTriggers()
    {
        _animator.ResetTrigger(Appear);
        _animator.ResetTrigger(Disappear);
    }
}
