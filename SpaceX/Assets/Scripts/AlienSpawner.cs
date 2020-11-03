using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlienSpawner : MonoBehaviour
{
    public static bool startSpawning = false;
    public List<GameObject> aliens;
    public static List<int> notSpawnedAliens = new List<int>();

    public const float InitialDelay = 0f;


    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < aliens.Count; i++)
        {
            notSpawnedAliens.Add(i);
        }
    }

    private void Update()
    {
        if (startSpawning)
        {
            StartCoroutine(SpawnAlien(0f));
            startSpawning = false;
        }
    }

    public IEnumerator SpawnAlien(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (notSpawnedAliens.Count > 0)
        {
            var randomAlienIndex = Random.Range(0, notSpawnedAliens.Count); // 0 - 3
            // randomAlienIndex = 3;
            var position = transform.position;
            var spawnedAlien = Instantiate(aliens[notSpawnedAliens[randomAlienIndex]], position, Quaternion.identity);
            Alien.currentAlien = spawnedAlien.GetComponent<Alien>();
            IceCream.wrongChoiceCount = 0;
            notSpawnedAliens.RemoveAt(randomAlienIndex);
        }
    }
}