using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public GameObject heroRPrefab;
    public List<Sprite> iceCreams;
    public GameObject iceCreamHolder;
    private int _wrongIceCreamTryCount = 0;
    private Animator _animator;
    private Transform _player;
    private Transform _heroRSeat;
    private static readonly int GiveIceCream = Animator.StringToHash("giveIceCream");
    private static readonly int StaticStanding = Animator.StringToHash("staticStanding");
    private static readonly int HeroStart = Animator.StringToHash("heroStart");
    private static readonly int FailedIceCreamCount = Animator.StringToHash("failedIceCreamCount");

    // Start is called before the first frame update
    void Start()
    {
        // disable rocket moving
        MoveByTouch.enableMoving = false;

        // get components
        _animator = GetComponent<Animator>();

        // change sorting layers
        var layerName = "Default";
        var orderOffset = 0;

        if (ChangeScene.currentScene == "Space")
        {
            layerName = "Player";
            orderOffset = 0;
            ChangeSortingLayer(transform.GetChild(0), layerName, orderOffset);

            _player = FindObjectOfType<Player>().transform;
            _heroRSeat = FindObjectOfType<Player>().transform.Find("HeroSeat");
        }
        else if (ChangeScene.currentScene == "Uranus")
        {
            _animator.SetBool(StaticStanding, true);
        }

        ChangeSortingLayer(transform.GetChild(0), layerName, orderOffset);

        bool startOver = true;
        if (PlayerPrefs.HasKey("playedMiniGame"))
        {
            startOver = PlayerPrefs.GetString("playedMiniGame") == "true";
        }

        if (ChangeScene.currentScene == "Space" && startOver)
        {
            // Hero Start Jumping
            StartCoroutine(Delay(2f));
            _animator.SetBool(HeroStart, true);
        }
    }

    public void ChangeSortingLayer(Transform element, string layerName, int orderOffset)
    {
        if (element.childCount > 0)
        {
            if (element.GetComponent<SpriteRenderer>() != null)
            {
                element.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                element.GetComponent<SpriteRenderer>().sortingOrder += orderOffset;
            }

            for (int i = 0; i < element.childCount; i++)
            {
                ChangeSortingLayer(element.GetChild(i), layerName, orderOffset);
            }
        }
        else
        {
            if (element.GetComponent<SpriteRenderer>() != null)
            {
                element.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                element.GetComponent<SpriteRenderer>().sortingOrder += orderOffset;
            }
        }
    }

    public void HeroRStart()
    {
        var heroR = Instantiate(heroRPrefab, _heroRSeat.localPosition, quaternion.identity);
        heroR.transform.localScale = _heroRSeat.transform.localScale;
        heroR.transform.SetParent(_player.transform);
    }

    public void Disable()
    {
        MoveByTouch.enableMoving = true;
        gameObject.SetActive(false);
    }


    public void GiveAlienPickUpIceCream(int alien, int iceCream)
    {
        iceCreamHolder.GetComponent<SpriteRenderer>().sprite = iceCreams[iceCream];
        switch (alien)
        {
            case 1:
                _animator.SetInteger(GiveIceCream, 1);
                break;
            case 2:
                _animator.SetInteger(GiveIceCream, 2);
                break;
            default:
                break;
        }
    }

    public void GiveAlienWrongIceCream(int tryCount, int iceCream)
    {
        _wrongIceCreamTryCount = tryCount;
        iceCreamHolder.GetComponent<SpriteRenderer>().sprite = iceCreams[iceCream];
        _animator.SetInteger(GiveIceCream, 3);
    }

    public void AlienFailedIceCreamStart()
    {
        switch (_wrongIceCreamTryCount)
        {
            case 1:
                Alien.currentAlien.GetComponent<Animator>().SetInteger(FailedIceCreamCount, 1);
                break;
            case 2:
                Alien.currentAlien.GetComponent<Animator>().SetInteger(FailedIceCreamCount, 2);
                break;
        }
    }

    public void AlienPickUpIceCream(int alien)
    {
        if (Alien.currentAlien.name.Contains(alien.ToString()))
        {
            // Alien.currentAlien.DestroyIceCream();
            Alien.currentAlien.GotIceCream();
        }
    }

    public void ResetAnimatorParameters()
    {
        _animator.SetInteger(GiveIceCream, 0);
    }

    IEnumerator Delay(float seconds)
    {
        var estimated = 0.0f;

        while (estimated < Time.fixedDeltaTime)
        {
            estimated += Time.fixedDeltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}