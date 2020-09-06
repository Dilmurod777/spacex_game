using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupiterMiniGameController : MonoBehaviour
{
    public GameObject camera;
    public GameObject mainCamera;
    public GameObject canvas;
    public GameObject playBtn;
    public GameObject planet;
    public GameObject mainCanvas;
    private GameObject _player;
    private Animator _planetAnimator;

    private string[] _FRUITS = {"Apple", "Banana", "Strawberry", "Cherry", "Blackberry", "Blueberry",};
    public static int _firstSelectedFruitIndex = -1;

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
    }

    public void StartGame()
    {
        MoveByTouch.enableMoving = false;
        _player.SetActive(false);
        mainCamera.SetActive(false);
        playBtn.gameObject.SetActive(false);
        planet.transform.GetChild(1).gameObject.SetActive(false);
        camera.SetActive(true);
        canvas.SetActive(true);
    }

    public void FruitSelected(int index)
    {
        if (_firstSelectedFruitIndex == -1)
        {
            _firstSelectedFruitIndex = index;
        }
        else
        {
            _planetAnimator.SetInteger("animationOption", _animationOptions[_firstSelectedFruitIndex, index]);
        }
    }
}