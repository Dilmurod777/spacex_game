using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudIceCream : MonoBehaviour
{
    private static int _alienIndex;
    private static int _iceCreamIndex;
    private static Animator _animator;
    private Hero _hero;
    
    private void Start()
    {
        _hero = FindObjectOfType<Hero>();
        _animator = GetComponent<Animator>();
    }

    public static void SetCurrentData(int pAlienIndex, int pIceCreamIndex)
    {
        _alienIndex = pAlienIndex;
        _iceCreamIndex = pIceCreamIndex;
        _animator.SetTrigger("removeIceCream");   
    }

    public void StartGivingIceCream()
    {
        _hero.GiveAlienPickUpIceCream(_alienIndex, _iceCreamIndex);
    }
}
