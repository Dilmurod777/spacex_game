using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasHandler : MonoBehaviour
{
    public void UranusPlayBtnHandler()
    {
        Debug.Log("URANUS");
        SceneManager.LoadScene("Uranus");
    }
}
