using UnityEngine;
using UnityEngine.EventSystems;

public class IceCream : MonoBehaviour, IPointerClickHandler
{
    public int index;
    public static int wrongChoiceCount;
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

    private void IceCreamClicked()
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
                    CloudIceCream.SetCurrentData(1, index);
                    CloudIceCream.RemoveIceCream("Success");
                }
                else if (Alien.currentAlien.name.StartsWith("Alien (2)"))
                {
                    CloudIceCream.SetCurrentData(2, index);
                    CloudIceCream.RemoveIceCream("Success");
                }
            }
            else
            {
                wrongChoiceCount += 1;
                Alien.currentAlien.isAnimating = true;
                switch (wrongChoiceCount)
                {
                    case 1:
                        Alien.currentAlien.GetComponent<Animator>().SetInteger(FailedIceCreamCount, 1);
                        break;
                    case 2:
                        CloudIceCream.RemoveIceCream("Failed");
                        wrongChoiceCount = 0;
                        break;
                }
            }
        }
    }
}