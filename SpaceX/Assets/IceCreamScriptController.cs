using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamScriptController : MonoBehaviour
{
    public List<GameObject> iceCreams;
    private int chosenIceCream;

    public void iceCreamClickHandler(int index)
    {
        chosenIceCream = index;
    }
}
