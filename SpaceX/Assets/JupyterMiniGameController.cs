using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupyterMiniGameController : MonoBehaviour
{
    public GameObject camera;
    public GameObject mainCamera;
    public GameObject canvas;
    public GameObject playBtn;
    public GameObject planet;
    public GameObject mainCanvas;
    private GameObject _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
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
}
