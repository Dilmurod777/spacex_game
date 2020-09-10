using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackOutPanel : MonoBehaviour
{
    public static String minigame;
    
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
        switch (minigame)
        {
            case "Jupiter":
                startJupiterMiniGame();
                break;
            case "Uranus":
                startUranusMiniGame();
                break;
        }
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
    
    public void startUranusMiniGame()
    {
        SceneManager.LoadScene("Uranus");
    }
}
