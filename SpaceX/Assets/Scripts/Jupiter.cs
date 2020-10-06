using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jupiter : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ResetAnimation()
    {
        if (_animator.speed > 0)
        {
            StartCoroutine(Delay(2f));
            _animator.SetTrigger("reset");
        }
    }

    public void idle()
    {
        _animator.ResetTrigger("reset");
        _animator.SetInteger("animationOption", -1);
        JupiterMiniGameController.firstSelectedFruitIndex = -1;
        JupiterMiniGameController.isPlanetAnimating = false;
    }
    
    IEnumerator Delay(float seconds)
    {
        var estimated = 0.0f;

        while (estimated < Time.fixedDeltaTime)
        {
            estimated += Time.fixedDeltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}