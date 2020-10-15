using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
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

        StartCoroutine(SpawnAlien(InitialDelay));
    }

    public IEnumerator SpawnAlien(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        var randomAlienIndex = Random.Range(0, notSpawnedAliens.Count); // 0 - 3
        randomAlienIndex = 0;
        var position = transform.position;
        var spawnedAlien = Instantiate(aliens[notSpawnedAliens[randomAlienIndex]], position, Quaternion.identity);
        Alien.currentAlien = spawnedAlien.GetComponent<Alien>();
        // notSpawnedAliens.RemoveAt(randomAlienIndex);
    }
}