using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public BlackOutPanel blackOutPanel;
    public GameObject asteroids;
    public GameObject stars;
    public GameObject comets;
    private GameObject _player;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Space")
        {
            _player = FindObjectOfType<Player>().gameObject;
        }
    }

    public void UranusPlayBtnHandler()
    {
        blackOutPanel.fadeInPanel();
        BlackOutPanel.minigame = "Uranus";
    }

    public void UranusExitBtnHandler()
    {
        SceneManager.LoadScene("Space");
    }

    public void JupyterPlayBtnHandler()
    {
        blackOutPanel.fadeInPanel();
        BlackOutPanel.minigame = "Jupiter";
        asteroids.SetActive(false);
        stars.SetActive(false);
        comets.SetActive(false);
    }

    public void JupyterExitBtnHandler()
    {
        SceneManager.LoadScene("Space");
    }
}