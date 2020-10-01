using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudIceCream : MonoBehaviour
{
    public static int alienIndex;
    public static int iceCreamIndex;
    private Hero _hero;
    
    private void Start()
    {
        _hero = FindObjectOfType<Hero>();
    }

    public static void SetCurrentData(int pAlienIndex, int pIceCreamIndex)
    {
        alienIndex = pAlienIndex;
        iceCreamIndex = pIceCreamIndex;
    }

    public void StartGivingIceCream()
    {
        _hero.GiveAlienPickUpIceCream(alienIndex, iceCreamIndex);
    }
}
