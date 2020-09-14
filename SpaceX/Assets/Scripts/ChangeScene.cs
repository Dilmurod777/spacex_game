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
        _player = FindObjectOfType<Player>().gameObject;
    }

    public void UranusPlayBtnHandler()
    {
        blackOutPanel.fadeInPanel();
        BlackOutPanel.minigame = "Uranus";

        PlayerPrefs.SetString("Uranus", "true");
        var position = _player.transform.position;
        PlayerPrefs.SetFloat("PositionX", position.x);
        PlayerPrefs.SetFloat("PositionY", position.y);
        PlayerPrefs.SetFloat("PositionZ", position.z);
        var rotation = _player.transform.rotation;
        PlayerPrefs.SetFloat("RotationX", rotation.x);
        PlayerPrefs.SetFloat("RotationY", rotation.y);
        PlayerPrefs.SetFloat("RotationZ", rotation.z);
    }

    public void UranusExitBtnHandler()
    {
        SceneManager.LoadScene("Space");
    }

    public void JupyterPlayBtnHandler()
    {
        blackOutPanel.fadeInPanel();
        asteroids.SetActive(false);
        stars.SetActive(false);
        comets.SetActive(false);
    }

    public void JupyterExitBtnHandler()
    {
        SceneManager.LoadScene("Space");
    }
}