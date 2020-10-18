using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroR : MonoBehaviour
{
    public GameObject solomka;
    private static Animator _animator;
    private static FruitSidePanel _sidePanel;
    private SpriteRenderer _solomkaHead;
    private SpriteRenderer _solomkaMiddle;
    private SpriteRenderer _solomkaTail;
    private int _defaultHeadSortingOrder;
    private int _defaultMiddleSortingOrder;
    private int _defaultTailSortingOrder;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();

        _solomkaHead = solomka.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _solomkaMiddle = solomka.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _solomkaTail = solomka.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<SpriteRenderer>();

        _defaultHeadSortingOrder = _solomkaHead.sortingOrder;
        _defaultMiddleSortingOrder = _solomkaMiddle.sortingOrder;
        _defaultTailSortingOrder = _solomkaTail.sortingOrder;
    }

    public static void HeroRDrink()
    {
        _animator.SetBool("drinkStart", true);
        _sidePanel = FindObjectOfType<FruitSidePanel>();
    }
    
    public void ResetDrinkTrigger()
    {
        _animator.SetBool("drinkStart", false);
        _sidePanel.MoveBack();
        JupiterMiniGameController.isRocketMoving = true;
    }

    public void ResetFruitSelected()
    {
        _animator.SetInteger("fruitSelected", -1);
        JupiterMiniGameController.isPlanetAnimating = false;
        JupiterMiniGameController.isRocketMoving = true;
        
    }


    public void InitializeSolomka()
    {
        _solomkaHead.sortingLayerName = "Player";
        _solomkaMiddle.sortingLayerName = "Player";
        _solomkaTail.sortingLayerName = "Default";
        _solomkaHead.sortingOrder = 14;
        _solomkaMiddle.sortingOrder = 15;
        _solomkaTail.sortingOrder = -5;
    }
    
    public void UpdateSolomka()
    {
        _solomkaHead.sortingLayerName = "Default";
        _solomkaMiddle.sortingLayerName = "Default";
        _solomkaTail.sortingLayerName = "Default";
        _solomkaHead.sortingOrder = -6;
        _solomkaMiddle.sortingOrder = -5;
        _solomkaTail.sortingOrder = -6;
    }
}
