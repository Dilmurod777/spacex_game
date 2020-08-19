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

    private void Start()
    {
        _alienSpawner = FindObjectOfType<AlienSpawner>();
    }

    public void IceCreamClickHandler(int index)
    {
        var alien = Alien.currentAlien;
        var alienGameObject = alien.gameObject;
        var endPoint = new Vector3(25f, alienGameObject.transform.position.y, 0);

        Debug.Log(alien.name);
        
        if (Alien.currentAlien.selectedIceCreamIndex == -1)
        {
            return;
        }

        if (Alien.currentAlien.selectedIceCreamIndex == index)
        {
            StartCoroutine(alienGameObject.GetComponent<Alien>().MoveOverSeconds(alienGameObject, endPoint, 10));
            MoveAlienDestroyIceCream(alienGameObject);
        }
        else
        {
            _wrongChoiceCount += 1;
            if (_wrongChoiceCount == 3)
            {
                StartCoroutine(alienGameObject.GetComponent<Alien>().MoveOverSeconds(alienGameObject, endPoint, 15));
                MoveAlienDestroyIceCream(alienGameObject);
            }
        }
    }

    private void MoveAlienDestroyIceCream(GameObject alien)
    {
        // Destroy(alien.transform.GetChild(0).gameObject); // destroy ice cream above alien
        if (AlienSpawner.notSpawnedAliens.Count > 0)
        {
            StartCoroutine(_alienSpawner.SpawnAlien(0f));
        }
    }
}