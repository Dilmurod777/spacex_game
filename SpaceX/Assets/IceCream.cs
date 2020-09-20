using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IceCream : MonoBehaviour, IPointerClickHandler
{
    public int index;
    private static int _wrongChoiceCount = 0;
    private Hero _hero;

    private void Start()
    {
        _hero = FindObjectOfType<Hero>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IceCreamClicked();
    }

    void IceCreamClicked()
    {
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1 || Alien.isAnimating)
        {
            return;
        }

        Debug.Log(Alien.currentAlien.name + " | " + Alien.currentAlien.selectedIceCreamIndex + " |  " + index);
        if (Alien.currentAlien.selectedIceCreamIndex == index)
        {
            // Alien.currentAlien.GotIceCream();
            // Alien.currentAlien.DestroyIceCream();
            if (Alien.currentAlien.name.StartsWith("Alien (1)") || Alien.currentAlien.name.StartsWith("Alien (4)"))
            {
                _hero.GiveAlienPickUpIceCream(1);
            }
            else if (Alien.currentAlien.name.StartsWith("Alien (2)"))
            {
                _hero.GiveAlienPickUpIceCream(2);
            }
        }
        else
        {
            _wrongChoiceCount += 1;
            switch (_wrongChoiceCount)
            {
                case 1:
                    Alien.currentAlien.GetComponent<Animator>().SetInteger("failedIceCreamCount", 1);
                    break;
                case 2:
                    Alien.currentAlien.GetComponent<Animator>().SetInteger("failedIceCreamCount", 2);
                    Alien.currentAlien.DestroyIceCream();
                    _wrongChoiceCount = 0;
                    break;
            }
        }
    }
}