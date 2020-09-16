using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IceCream : MonoBehaviour, IPointerClickHandler
{
    public int index;
    private static int _wrongChoiceCount = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        IceCreamClicked();
    }
    
    void IceCreamClicked()
    {
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1 || Alien.currentAlien.iaAnimating)
        {
            return;
        }

        if (Alien.currentAlien.selectedIceCreamIndex == index)
        {
            Alien.currentAlien.GotIceCream();
            Alien.currentAlien.DestroyIceCream();
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