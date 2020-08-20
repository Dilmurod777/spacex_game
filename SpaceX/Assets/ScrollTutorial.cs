using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTutorial : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        Invoke("StartTutorial", 1);
    }

    private void StartTutorial()
    {
        _animator.SetTrigger("startTutorial");
    }
}