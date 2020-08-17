using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public List<GameObject> aliens;

    private readonly List<float> _yOffsets = new List<float>();
    private readonly List<int> _notSpawnedAliens = new List<int>();
    public List<GameObject> spawnedAliens = new List<GameObject>();

    private const float InitialDelay = 2f;
    private const float TimeBetweenSpawns = 5f;


    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < aliens.Count; i++)
        {
            _notSpawnedAliens.Add(i);
        }

        _yOffsets.Add(0f); // 0 offset for alien 1
        _yOffsets.Add(-0.56f); // 0 offset for alien 2
        _yOffsets.Add(0.7f); // 0 offset for alien 3
        _yOffsets.Add(0f); // 0 offset for alien 4


        StartCoroutine(SpawnAlien(InitialDelay));
    }

    private IEnumerator SpawnAlien(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        var randomAlienIndex = Random.Range(0, _notSpawnedAliens.Count); // 0 - 4
        var position = transform.position + new Vector3(0, _yOffsets[randomAlienIndex], 0);
        var spawnedAlien = Instantiate(aliens[_notSpawnedAliens[randomAlienIndex]], position, Quaternion.identity);
        _notSpawnedAliens.RemoveAt(randomAlienIndex);

        spawnedAliens.Add(spawnedAlien);
    }
}