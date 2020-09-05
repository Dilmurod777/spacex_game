using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angar : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        MoveByTouch.enableMoving = false;
    }

    public void SortingLayerToPlayer()
    {
        _player.transform.localScale = new Vector3(1f, 1f, _player.transform.localScale.z);
        ChangeSortingLayer(_player.transform.GetChild(0), "Player");
        MoveByTouch.enableMoving = true;
    }

    public void SortingLayerToDefault()
    {
        _player.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
        ChangeSortingLayer(_player.transform.GetChild(0), "Default");
        MoveByTouch.enableMoving = true;
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

    public void closeAngar()
    {
        GetComponent<Animator>().ResetTrigger("close");
    }
}