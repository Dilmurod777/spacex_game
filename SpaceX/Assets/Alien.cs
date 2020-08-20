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
    private const float walkingTime = 4.5f;
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
            _selectedIceCream = Instantiate(iceCreams[selectedIceCreamIndex], transform.position,
                Quaternion.identity);
            _selectedIceCream.transform.SetParent(transform);
            _selectedIceCream.transform.localPosition = new Vector3(0, 8f, 0);
        }
    }

    public void StartMovingAlien(Vector3 pointToGo, float seconds = 0f, float delay = 0f)
    {
        _stopMoving = false;
        _cameToShop = false;
        StartMovingCoroutine(pointToGo, seconds, delay);
    }

    private IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        var startingPos = objectToMove.transform.position;

        while (elapsedTime < seconds)
        {
            if (objectToMove)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos,
                    new Vector3(end.x, startingPos.y, startingPos.z), (elapsedTime / seconds));
                elapsedTime += Time.fixedDeltaTime;
                yield return new WaitForEndOfFrame();
            }
            else
            {
                StopCoroutine(_movingCoroutine);
            }
        }

        // objectToMove.transform.position = new Vector3(end.x, startingPos.y, startingPos.z);
        StartCoroutine(Delay(5f));
        _animator.SetTrigger("cameToShop");
        _cameToShop = true;
    }

    public void StartMovingCoroutine(Vector3 pointToGo, float seconds, float delay)
    {
        StartCoroutine(Delay(delay));

        _animator.SetTrigger("startWalking");
        _movingCoroutine = StartCoroutine(MoveOverSeconds(gameObject, pointToGo, seconds));
    }

    public void StopMovingCoroutine()
    {
        StopCoroutine(_movingCoroutine);
    }

    private IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            _stopMoving = true;
        }
    }
}