using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public BlackOutPanel blackOutPanel;
    public GameObject jupyterPlayBtn;
    public GameObject asteroids;
    public GameObject stars;
    public GameObject comets;
    
    public void UranusPlayBtnHandler()
    {
        SceneManager.LoadScene("Uranus");
    }

    public void UranusExitBtnHandler()
    {
        SceneManager.LoadScene("Space");
    }

    public void JupyterPlayBtnHandler()
    {
        blackOutPanel.fadeInPanel();
        jupyterPlayBtn.SetActive(false);
        asteroids.SetActive(false);
        stars.SetActive(false);
        comets.SetActive(false);
    }
    
}