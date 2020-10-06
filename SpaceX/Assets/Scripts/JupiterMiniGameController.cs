using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupiterMiniGameController : MonoBehaviour
{
    public static bool isPlanetAnimating = false;
    public GameObject camera;
    public GameObject mainCamera;
    public GameObject canvas;
    public GameObject playBtn;
    public GameObject planet;
    public GameObject mainCanvas;
    public GameObject rocketHolder;
    public GameObject solomka;
    private GameObject _player;
    private Animator _planetAnimator;
    private Animator _heroRAnimator;

    private string[] _fruits = {"Apple", "Banana", "Strawberry", "Cherry", "Blackberry", "Blueberry",};
    public static int firstSelectedFruitIndex = -1;

    private readonly int[,] _animationOptions =
    {
        {00, 01, 02, 03, 04, 05},
        {01, 06, 07, 08, 09, 10},
        {02, 07, 11, 12, 13, 14},
        {03, 08, 12, 15, 16, 17},
        {04, 09, 13, 16, 18, 19},
        {05, 10, 14, 17, 19, 20},
    };

    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _planetAnimator = planet.GetComponent<Animator>();
        camera.SetActive(false);
        canvas.SetActive(false);
        solomka.SetActive(false);
    }

    public void StartGame()
    {
        MoveByTouch.enableMoving = false;
        _heroRAnimator = _player.transform.GetChild(_player.transform.childCount - 1).gameObject.GetComponent<Animator>();
        

        mainCamera.SetActive(false);
        playBtn.gameObject.SetActive(false);
        planet.transform.GetChild(0).gameObject.SetActive(true);
        planet.transform.GetChild(1).gameObject.SetActive(false);
        camera.SetActive(true);
        canvas.SetActive(true);
        // solomka.SetActive(true);
        _player.transform.position = rocketHolder.transform.position;
        _player.transform.rotation = rocketHolder.transform.rotation;
        _player.transform.localScale = rocketHolder.transform.localScale;
        Invoke("TurnHeroRWithDelay", 2f);
    }

    public void FruitSelected(int index)
    {
        if (!isPlanetAnimating)
        {
            if (firstSelectedFruitIndex == -1)
            {
                firstSelectedFruitIndex = index;
            }
            else
            {
                isPlanetAnimating = true;
                _heroRAnimator.SetTrigger("drink");
                _planetAnimator.SetInteger("animationOption", _animationOptions[firstSelectedFruitIndex, index]);
            }
        }
    }
    
    void TurnHeroRWithDelay()
    {
        _heroRAnimator.SetBool("isJupiter", true);
    }
}