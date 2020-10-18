using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class JupiterMiniGameController : MonoBehaviour
{
    public static bool isPlanetAnimating = false;
    public static bool isRocketMoving = false;
    public GameObject camera;
    public GameObject mainCamera;
    public GameObject canvas;
    public GameObject playBtn;
    public GameObject planet;
    public GameObject mainCanvas;
    public GameObject rocketHolder;
    public GameObject rocketMovePoints;
    public FruitSidePanel sidePanel;
    private GameObject _player;
    private Animator _planetAnimator;
    private Animator _heroRAnimator;
    private int _currentRocketMovePoint = 0;
    private float _speed = 0.3f;

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
    }

    private void FixedUpdate()
    {
        if (isRocketMoving)
        {
            if (_player.transform.position != rocketMovePoints.transform.GetChild(_currentRocketMovePoint).position)
            {
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, rocketMovePoints.transform.GetChild(_currentRocketMovePoint).position,
                    _speed * Time.deltaTime);
            }
            else
            {
                _currentRocketMovePoint = (_currentRocketMovePoint + 1) % rocketMovePoints.transform.childCount;
            }
        }
    }

    public void StartGame()
    {
        MoveByTouch.enableMoving = false;
        isRocketMoving = true;
        _heroRAnimator = _player.transform.GetChild(_player.transform.childCount - 1).gameObject.GetComponent<Animator>();
        
        mainCamera.SetActive(false);
        playBtn.gameObject.SetActive(false);
        planet.transform.GetChild(0).gameObject.SetActive(true);
        planet.transform.GetChild(1).gameObject.SetActive(false);
        camera.SetActive(true);
        canvas.SetActive(true);
        _player.transform.position = rocketHolder.transform.position;
        _player.transform.rotation = rocketHolder.transform.rotation;
        _player.transform.localScale = rocketHolder.transform.localScale;
    }

    public void ExitGame()
    {
        isRocketMoving = false;
        SceneManager.LoadScene("Space");
    }

    public void FruitSelected(int index)
    {
        if (!isPlanetAnimating)
        {
            isRocketMoving = false;
            if (firstSelectedFruitIndex == -1)
            {
                firstSelectedFruitIndex = index;
                isPlanetAnimating = true;

                var happyIndex = Random.Range(0, 2);
                _heroRAnimator.SetInteger("fruitSelected", happyIndex);
            }
            else
            {
                isPlanetAnimating = true;
                sidePanel.MoveAside();
                _planetAnimator.SetInteger("animationOption", _animationOptions[firstSelectedFruitIndex, index]);
            }
        }
    }
}