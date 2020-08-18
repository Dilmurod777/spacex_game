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
        if (Alien.selectedIceCreamIndex == index)
        {
            Debug.Log("Correct");
            var alien = Alien.currentAlien;
            var endPoint = new Vector3(25f, alien.transform.position.y, 0);
            StartCoroutine(alien.GetComponent<Alien>().MoveOverSeconds(alien, endPoint, 10));
            Destroy(alien.transform.GetChild(0).gameObject); // destroy ice cream above alien

            Alien.selectedIceCreamIndex = -1;
            if (AlienSpawner._notSpawnedAliens.Count > 0)
            {
                StartCoroutine(_alienSpawner.SpawnAlien(0f));
            }
        }
        else
        {
            Debug.Log("Wrong");
            _wrongChoiceCount += 1;
            if (_wrongChoiceCount == 3)
            {
                var alien = Alien.currentAlien;
                var endPoint = new Vector3(25f, alien.transform.position.y, 0);
                StartCoroutine(alien.GetComponent<Alien>().MoveOverSeconds(alien, endPoint, 15));
                Destroy(alien.transform.GetChild(0).gameObject); // destroy Ice cream alien
                
                Alien.selectedIceCreamIndex = -1;
                if (AlienSpawner._notSpawnedAliens.Count > 0)
                {
                    StartCoroutine(_alienSpawner.SpawnAlien(0f));
                }
            }
        }
    }
}