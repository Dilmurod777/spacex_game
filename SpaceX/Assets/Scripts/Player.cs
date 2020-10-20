using UnityEngine;

public class Player : MonoBehaviour
{
    public Hero hero;
    public GameObject heroRPrefab;
    public GameObject heroSeat;
    private BlackOutPanel _blackOutPanel;

    private void Start()
    {
        _blackOutPanel = FindObjectOfType<BlackOutPanel>();

        Debug.Log("Player Start()");
        if (PlayerPrefs.GetString("playedMiniGame").Equals("true"))
        {
            _blackOutPanel.fadeOutPanelAfterMiniGame();
            InstantiateMiniGame("Space");
            FetchPreviousTransform();
        }
    }

    public void InstantiateMiniGame(string miniGame)
    {
        Debug.Log("Player InstantiateMiniGame() | " + miniGame);
        switch (miniGame)
        {
            case "Space":
                // disable default hero
                hero.Disable();
                // place heroR
                var heroR = Instantiate(heroRPrefab, heroSeat.transform.localPosition, Quaternion.identity);
                heroR.transform.localScale = heroSeat.transform.localScale;
                heroR.transform.SetParent(transform);
                break;
        }
    }

    public void DeletePreviousTransform()
    {
        PlayerPrefs.DeleteKey("positionX");
        PlayerPrefs.DeleteKey("positionY");
        PlayerPrefs.DeleteKey("positionZ");
        PlayerPrefs.DeleteKey("rotationX");
        PlayerPrefs.DeleteKey("rotationY");
        PlayerPrefs.DeleteKey("rotationZ");
        PlayerPrefs.DeleteKey("scaleX");
        PlayerPrefs.DeleteKey("scaleY");
        PlayerPrefs.DeleteKey("scaleZ");

        PlayerPrefs.DeleteKey("playedMiniGame");
    }

    public void StoreCurrentTransform()
    {
        DeletePreviousTransform();

        var tr = transform;
        var position = tr.position;
        var rotation = tr.rotation;
        var scale = tr.localScale;

        PlayerPrefs.SetFloat("positionX", position.x);
        PlayerPrefs.SetFloat("positionY", position.y);
        PlayerPrefs.SetFloat("positionZ", position.z);
        PlayerPrefs.SetFloat("rotationX", rotation.x);
        PlayerPrefs.SetFloat("rotationY", rotation.y);
        PlayerPrefs.SetFloat("rotationZ", rotation.z);
        PlayerPrefs.SetFloat("scaleX", scale.x);
        PlayerPrefs.SetFloat("scaleY", scale.y);
        PlayerPrefs.SetFloat("scaleZ", scale.z);

        PlayerPrefs.SetString("playedMiniGame", "true");
    }

    public void FetchPreviousTransform()
    {
        Debug.Log("fetch previous transform");

        var tr = transform;
        var position = tr.position;
        var rotation = tr.rotation;
        var scale = tr.localScale;

        position.x = PlayerPrefs.GetFloat("positionX");
        position.y = PlayerPrefs.GetFloat("positionY");
        position.z = PlayerPrefs.GetFloat("positionZ");

        rotation.x = PlayerPrefs.GetFloat("rotationX");
        rotation.y = PlayerPrefs.GetFloat("rotationY");
        rotation.z = PlayerPrefs.GetFloat("rotationZ");

        scale.x = PlayerPrefs.GetFloat("scaleX");
        scale.y = PlayerPrefs.GetFloat("scaleY");
        scale.z = PlayerPrefs.GetFloat("scaleZ");

        tr.position = position;
        tr.rotation = rotation;
        tr.localScale = scale;

        DeletePreviousTransform();
    }
}