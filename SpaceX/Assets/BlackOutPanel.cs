using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutPanel : MonoBehaviour
{
    private Animator _animator;
    private JupyterMiniGameController _jupyterMiniGameController;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _jupyterMiniGameController = FindObjectOfType<JupyterMiniGameController>();
        resetTriggers();
    }

    public void fadeInPanel()
    {
        _animator.SetTrigger("fadeIn");
    }

    public void fadeOutPanel()
    {
        _animator.SetTrigger("fadeOut");
    }

    public void resetTriggers()
    {
        _animator.ResetTrigger("fadeIn");
        _animator.ResetTrigger("fadeOut");
    }

    public void StartJupyterMiniGame()
    {
        _jupyterMiniGameController.StartGame();
    }
    
}
