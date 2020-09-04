using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien"))
        {
            Destroy(other.gameObject);
        }

        if (AlienSpawner.notSpawnedAliens.Count == 0)
        {
            // End of Mini Game
            SceneManager.LoadScene("Space");
        }
    }
}
