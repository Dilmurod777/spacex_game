using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public List<GameObject> aliens;

    private List<float> yOffsets = new List<float>();
    private List<int> notSpawnedAliens = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < aliens.Count; i++)
        {
            notSpawnedAliens.Add(i);
        }

        yOffsets.Add(0f); // 0 offset for alien 1
        yOffsets.Add(-0.56f); // 0 offset for alien 2
        yOffsets.Add(0.7f); // 0 offset for alien 3
        yOffsets.Add(0f); // 0 offset for alien 4


        for (int i = 0; i < aliens.Count; i++)
        {
            StartCoroutine(SpawnAlien(2 + 5 * i));
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

        int randomAlienIndex = Random.Range(0, notSpawnedAliens.Count); // 0 - 4
        Vector3 position = transform.position + new Vector3(0, yOffsets[randomAlienIndex], 0);
        GameObject spawnedAlien = Instantiate(aliens[notSpawnedAliens[randomAlienIndex]], position, Quaternion.identity);
        notSpawnedAliens.RemoveAt(randomAlienIndex);
    }
}
