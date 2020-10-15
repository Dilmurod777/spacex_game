using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroR : MonoBehaviour
{
    private static Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void HeroRDrink()
    {
        _animator.SetBool("drinkStart", true);
    }
    
    public void ResetDrinkTrigger()
    {
        _animator.SetBool("drinkStart", false);
    }

    public void ResetFruitSelected()
    {
        _animator.SetInteger("fruitSelected", -1);
        JupiterMiniGameController.isPlanetAnimating = false;
    }
}
