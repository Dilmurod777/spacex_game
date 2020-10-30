using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackOutPanel : MonoBehaviour
{
    public static bool doExitMiniGame = false;
    private Player _player;
    private Animator _animator;
    private JupiterMiniGameController _jupyterMiniGameController;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _jupyterMiniGameController = FindObjectOfType<JupiterMiniGameController>();
        if (PlayerPrefs.HasKey("playedMiniGame"))
        {
            resetTriggers();
        }

        if (ChangeScene.currentScene == "Uranus")
        {
            fadeOutPanelAfterMiniGame();
        }
    }

    public void fadeInPanel()
    {
        _animator.SetTrigger("fadeIn");
    }

    public void fadeOutPanelAfterMiniGame()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        _animator.SetTrigger("fadeOutMiniGame");
    }
    
    public void fadeOutPanelStartGame()
    {
        _animator.SetTrigger("fadeOut");
        
        switch (ChangeScene.currentScene)
        {
            case "Space":
                SwitchToSpaceGame();
                break;
            case "Jupiter":
                SwitchToJupiterMiniGame();
                break;
            case "Uranus":
                SwitchToUranusMiniGame();
                break;
        }
    }

    public void resetTriggers()
    {
        _animator.ResetTrigger("fadeIn");
        _animator.ResetTrigger("fadeOut");
        _animator.ResetTrigger("fadeOutMiniGame");
    }

    public void SwitchToSpaceGame()
    {
        SceneManager.LoadScene("Space");
    }
    
    public void SwitchToJupiterMiniGame()
    {
        FindObjectOfType<JupiterMiniGameController>().StartGame();
    }
    
    public void SwitchToUranusMiniGame()
    {
        _player.StoreCurrentTransform();
        SceneManager.LoadScene("Uranus");
    }

    public void StartMiniGame()
    {
        if (ChangeScene.currentScene == "Uranus")
        {
            AlienSpawner.startSpawning = true;
            ExitButton.appear = true;
        }
    }

    public void ExitMiniGame()
    {
        if (doExitMiniGame)
        {
            if (!ChangeScene.currentScene.Equals("Space"))
            {
                
                SceneManager.LoadScene("Space");
            }
        }
    }
    
}
