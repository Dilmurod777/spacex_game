using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamScriptController : MonoBehaviour
{
    private int _wrongChoiceCount = 0;
    private const int NumberOfFails = 2;

    private void Start()
    {
    }

    public void IceCreamClickHandler(int index)
    {
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1)
        {
            return;
        }

        if (Alien.currentAlien.selectedIceCreamIndex == index)
        {
            Alien.currentAlien.GetComponent<Animator>().SetTrigger("gotIceCream");
        }
        else
        {
            _wrongChoiceCount += 1;
            Alien.currentAlien.GetComponent<Animator>().SetInteger("failedIceCreamCount", _wrongChoiceCount);
            if (_wrongChoiceCount == NumberOfFails)
            {
                _wrongChoiceCount = 0;
            }

        }
    }
}