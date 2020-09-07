using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public GameObject heroRPrefab;
    private Animator _animator;
    private Transform _player;
    private Transform _heroRSeat;

    // Start is called before the first frame update
    void Start()
    {
        // disable rocket moving
        MoveByTouch.enableMoving = false;

        // get components
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>().transform;
        _heroRSeat = FindObjectOfType<Player>().transform.Find("HeroSeat");
        
        // change sorting layers
        var layerName = "Default";
        var orderOffset = 0;

        if (SceneManager.GetActiveScene().name == "Space")
        {
            layerName = "Player";
            orderOffset = 0;
        }

        ChangeSortingLayer(transform.GetChild(0), layerName, orderOffset);

        // Hero Start Jumping
        // StartCoroutine(Delay(2f));
        // _animator.SetBool("heroStart", true);
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
        var heroR = Instantiate(heroRPrefab, _heroRSeat.position, quaternion.identity);
        heroR.transform.localScale = _heroRSeat.transform.localScale;
        heroR.transform.SetParent(_player.transform);
    }

    public void Disable()
    {
        MoveByTouch.enableMoving = true;
        gameObject.SetActive(false);    
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