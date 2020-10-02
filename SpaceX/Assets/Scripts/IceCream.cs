using UnityEngine;
using UnityEngine.EventSystems;

public class IceCream : MonoBehaviour, IPointerClickHandler
{
    public int index;
    private static int _wrongChoiceCount;
    private Hero _hero;
    private static readonly int FailedIceCreamCount = Animator.StringToHash("failedIceCreamCount");

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
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1 || Alien.currentAlien.isAnimating)
        {
            return;
        }

        if (!Alien.currentAlien.isAnimating)
        {
            if (Alien.currentAlien.selectedIceCreamIndex == index)
            {
                Alien.currentAlien.isAnimating = true;
                if (Alien.currentAlien.name.StartsWith("Alien (1)") || Alien.currentAlien.name.StartsWith("Alien (4)") ||
                    Alien.currentAlien.name.StartsWith("Alien (3)"))
                {
                    // _hero.GiveAlienPickUpIceCream(1, index);
                    CloudIceCream.SetCurrentData(1, index);
                    CloudIceCream.RemoveIceCream("Success");
                }
                else if (Alien.currentAlien.name.StartsWith("Alien (2)"))
                {
                    // _hero.GiveAlienPickUpIceCream(2, index);
                    CloudIceCream.SetCurrentData(2, index);
                    CloudIceCream.RemoveIceCream("Success");
                }
                
            }
            else
            {
                _wrongChoiceCount += 1;
                Alien.currentAlien.isAnimating = true;
                switch (_wrongChoiceCount)
                {
                    case 1:
                        Alien.currentAlien.GetComponent<Animator>().SetInteger(FailedIceCreamCount, 1);
                        break;
                    case 2:
                        CloudIceCream.RemoveIceCream("Failed");
                        // Alien.currentAlien.GetComponent<Animator>().SetInteger(FailedIceCreamCount, 2);
                        // Alien.currentAlien.DestroyIceCream();
                        _wrongChoiceCount = 0;
                        break;
                }
            }
        }
    }
}