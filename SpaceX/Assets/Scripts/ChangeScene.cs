using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void UranusPlayBtnHandler()
    {
        SceneManager.LoadScene("Uranus");
    }

    public void UranusExitBtnHandler()
    {
        SceneManager.LoadScene("Space");
    }
}
