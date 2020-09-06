using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var layerName = "Default";
        var orderOffset = 0;

        if (SceneManager.GetActiveScene().name == "Space")
        {
            layerName = "Player";
            orderOffset = 100;
        }
        
        ChangeSortingLayer(transform.GetChild(0), layerName, orderOffset);
    }

    public void ChangeSortingLayer(Transform element, string layerName, int orderOffset)
    {
        if (element.childCount > 0)
        {
            if (element.GetComponent<SpriteRenderer>() != null)
            {
                element.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                element.GetComponent<SpriteRenderer>().sortingOrder += orderOffset;
            }

            for (int i = 0; i < element.childCount; i++)
            {
                ChangeSortingLayer(element.GetChild(i), layerName, orderOffset);
            }
        }
        else
        {
            if (element.GetComponent<SpriteRenderer>() != null)
            {
                element.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                element.GetComponent<SpriteRenderer>().sortingOrder += orderOffset;
            }
        }
    }
}
