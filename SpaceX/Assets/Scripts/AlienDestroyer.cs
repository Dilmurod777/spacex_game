using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienDestroyer : MonoBehaviour
{
    public static int removedAliens = 0;
    public static int totalNumberOfSpawns = 4;
    public BlackOutPanel blackOutPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.CompareTag("Alien"))
        {
            Destroy(other.transform.parent.gameObject);
            removedAliens += 1;
        }

        if (removedAliens == totalNumberOfSpawns)
        {
            ChangeScene.currentScene = "Space";
            blackOutPanel.fadeInPanel();
            BlackOutPanel.doExitMiniGame = true;
        }
    }
}