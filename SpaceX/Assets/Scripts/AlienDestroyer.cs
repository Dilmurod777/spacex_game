﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienDestroyer : MonoBehaviour
{
    public static int removedAliens = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.CompareTag("Alien"))
        {
            Destroy(other.transform.parent.gameObject);
            removedAliens += 1;
        }

        if (removedAliens == 4)
        {
            SceneManager.LoadScene("Space");
        }
    }
}