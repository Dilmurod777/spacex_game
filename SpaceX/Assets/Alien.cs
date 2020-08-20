using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Alien : MonoBehaviour
{
    public List<GameObject> iceCreams;
    public Transform endPoint;
    public float walkingTime = 5;
    private bool _stopMoving = false;
    private bool _cameToShop = false;
    private GameObject _selectedIceCream;
    public int selectedIceCreamIndex = -1;
    public static Alien currentAlien;

    private Coroutine _movingCoroutine;
    private Animator _animator;
    
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.ResetTrigger("startWalking");
        _animator.ResetTrigger("cameToShop");
        // set current Alien as the one that was instantiated
        StartMovingAlien(new Vector3(endPoint.position.x, transform.position.y), walkingTime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_stopMoving)
        {
            StopAllCoroutines();
        }

        if (_cameToShop && selectedIceCreamIndex == -1)
        {
            selectedIceCreamIndex = new Random().Next(0, iceCreams.Count);
            _selectedIceCream = Instantiate(iceCreams[selectedIceCreamIndex], transform.position + new Vector3(0, 5, 0),
                Quaternion.identity);
            _selectedIceCream.transform.SetParent(transform);
        }
    }

    public void StartMovingAlien(Vector3 pointToGo, float seconds = 0f, float delay = 2f)
    {
        _stopMoving = false;
        _cameToShop = false;
        StartCoroutine(StartMovingCoroutine(pointToGo, seconds, delay));
    }

    private IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        var startingPos = objectToMove.transform.position;

        while (elapsedTime < seconds)
        {
            if (objectToMove)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, new Vector3(end.x, startingPos.y, startingPos.z), (elapsedTime / seconds));
                elapsedTime += Time.fixedDeltaTime;
                yield return new WaitForEndOfFrame();
            }
            else
            {
                StopCoroutine(_movingCoroutine);
            }
        }

        // objectToMove.transform.position = new Vector3(end.x, startingPos.y, startingPos.z);
        _cameToShop = true;
        _animator.SetTrigger("cameToShop");
    }

    public IEnumerator StartMovingCoroutine(Vector3 pointToGo, float seconds, float delay)
    {
        var elapsed = 0.0f;
        while (elapsed < delay)
        {
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        _animator.SetTrigger("startWalking");
        _movingCoroutine = StartCoroutine(MoveOverSeconds(gameObject, pointToGo, seconds));
    }
    
    public void StopMovingCoroutine()
    {
        StopCoroutine(_movingCoroutine);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            _stopMoving = true;
        }
    }
}