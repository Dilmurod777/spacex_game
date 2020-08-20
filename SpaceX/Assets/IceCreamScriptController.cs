using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamScriptController : MonoBehaviour
{
    public List<GameObject> iceCreams;
    private int _chosenIceCream;
    private int _wrongChoiceCount = 0;
    private AlienSpawner _alienSpawner;
    public Alien alien;
    private GameObject _alienGameObject;

    private void Start()
    {
        _alienSpawner = FindObjectOfType<AlienSpawner>();
    }

    private void FixedUpdate()
    {
        if (!Alien.currentAlien) return;

        alien = Alien.currentAlien;
        _alienGameObject = alien.gameObject;
    }

    public void IceCreamClickHandler(int index)
    {
        var endPoint = new Vector3(25f, _alienGameObject.transform.position.y, 0);
        
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1)
        {
            return;
        }
        
        if ( Alien.currentAlien.selectedIceCreamIndex == index)
        {
            // StartCoroutine(_alienGameObject.GetComponent<Alien>().MoveOverSeconds(_alienGameObject, endPoint, 10));
            alien.StartMovingAlien(endPoint, 10, 0);
            MoveAlienDestroyIceCream(_alienGameObject);
        }
        else
        {
            _wrongChoiceCount += 1;
            if (_wrongChoiceCount == 3)
            {
                // StartCoroutine(_alienGameObject.GetComponent<Alien>().MoveOverSeconds(_alienGameObject, endPoint, 15));
                alien.StartMovingAlien(endPoint, 15, 0);
                MoveAlienDestroyIceCream(_alienGameObject);
                _wrongChoiceCount = 0;
            }
        }
    }

    private void MoveAlienDestroyIceCream(GameObject alien)
    {
        // need to remove Ice Cream
        if (AlienSpawner.notSpawnedAliens.Count > 0)
        {
            StartCoroutine(_alienSpawner.SpawnAlien(0f));
        }
    }
}