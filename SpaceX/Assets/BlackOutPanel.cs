﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutPanel : MonoBehaviour
{
    private Animator _animator;
    private JupiterMiniGameController _jupyterMiniGameController;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _jupyterMiniGameController = FindObjectOfType<JupiterMiniGameController>();
        resetTriggers();
    }

    public void fadeInPanel()
    {
        _animator.SetTrigger("fadeIn");
    }

    public void fadeOutPanel()
    {
        _animator.SetTrigger("fadeOut");
        startJupiterMiniGame();
    }

    public void resetTriggers()
    {
        _animator.ResetTrigger("fadeIn");
        _animator.ResetTrigger("fadeOut");
    }

    public void startJupiterMiniGame()
    {
        FindObjectOfType<JupiterMiniGameController>().StartGame();
    }
}
