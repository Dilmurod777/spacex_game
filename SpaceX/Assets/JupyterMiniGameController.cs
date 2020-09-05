using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupyterMiniGameController : MonoBehaviour
{
    public GameObject planet;
    public GameObject playBtn;
    private Camera _cam;
    private GameObject _player;
    private void Start()
    {
        _cam = Camera.main;
        _player = FindObjectOfType<Player>().gameObject;
    }

    public void StartGame()
    {
        MoveByTouch.enableMoving = false;
        playBtn.SetActive(false);
        _player.SetActive(false);
        
        _cam.fieldOfView = 100;
        _cam.transform.position = planet.transform.position;
    }
}
