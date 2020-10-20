using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angar : MonoBehaviour
{
    public bool doOpenAngar = true;
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
    }

    public void SortingLayerToPlayer()
    {
        _player.transform.localScale = new Vector3(1f, 1f, _player.transform.localScale.z);
        ChangeSortingLayer(_player.transform.GetChild(0), "Player");
    }

    public void SortingLayerToDefault()
    {
        _player.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
        ChangeSortingLayer(_player.transform.GetChild(0), "Default");
    }

    public void ChangeSortingLayer(Transform element, string layerName)
    {
        if (element.childCount > 0)
        {
            if (element.GetComponent<SpriteRenderer>() != null)
            {
                element.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }

            for (int i = 0; i < element.childCount; i++)
            {
                ChangeSortingLayer(element.GetChild(i), layerName);
            }
        }
        else
        {
            if (element.GetComponent<SpriteRenderer>() != null)
            {
                element.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }
        }
    }

    public void openAngar()
    {
        if (doOpenAngar)
        {
            GetComponent<Animator>().SetTrigger("open");
        }
    }

    public void closeAngar()
    {
        GetComponent<Animator>().ResetTrigger("close");
    }
}