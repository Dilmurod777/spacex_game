﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamScriptController : MonoBehaviour
{
    private int _chosenIceCream;
    private int _wrongChoiceCount = 0;
    private AlienSpawner _alienSpawner;
    private const int NumberOfFails = 2;

    private void Start()
    {
        _alienSpawner = FindObjectOfType<AlienSpawner>();
    }

    public void IceCreamClickHandler(int index)
    {
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1)
        {
            return;
        }

        if (Alien.currentAlien.selectedIceCreamIndex == index)
        {
            Debug.Log("CORRECT");
            Alien.currentAlien.GetComponent<Animator>().SetTrigger("gotIceCream");
            MoveAlienDestroyIceCream();
        }
        else
        {
            Debug.Log("Wrong");
            if (_wrongChoiceCount == NumberOfFails)
            {
                Alien.currentAlien.GetComponent<Animator>().SetTrigger("failedIceCream");
                MoveAlienDestroyIceCream();
                _wrongChoiceCount = 0;
            }

            _wrongChoiceCount += 1;
        }
    }

    private void MoveAlienDestroyIceCream()
    {
        // remove IceCream
        Destroy(Alien.currentAlien.transform.GetChild(1).gameObject);
        
        // Instantiate next alien
        if (AlienSpawner.notSpawnedAliens.Count > 0)
        {
            StartCoroutine(_alienSpawner.SpawnAlien(0f));
        }
    }
}