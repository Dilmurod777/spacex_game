using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public static String currentScene = "Space";
    public BlackOutPanel blackOutPanel;
    public GameObject asteroids;
    public GameObject stars;
    public GameObject comets;
    private Player _player;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Space")
        {
            _player = FindObjectOfType<Player>();
            BlackOutPanel.doExitMiniGame = false;
        }
    }

    public void UranusPlayBtnHandler()
    {
        currentScene = "Uranus";
        _player.StoreCurrentTransform();
        blackOutPanel.fadeInPanel();
    }

    public void UranusExitBtnHandler()
    {
        currentScene = "Space";
        blackOutPanel.fadeInPanel();
        BlackOutPanel.doExitMiniGame = true;
    }

    public void JupyterPlayBtnHandler()
    {
        currentScene = "Jupiter";
        _player.StoreCurrentTransform();
        asteroids.SetActive(false);
        stars.SetActive(false);
        comets.SetActive(false);
        blackOutPanel.fadeInPanel();
    }

    public void JupyterExitBtnHandler()
    {
        JupiterMiniGameController.isRocketMoving = false;
        currentScene = "Space";
        blackOutPanel.fadeInPanel();
        BlackOutPanel.doExitMiniGame = true;
    }
}