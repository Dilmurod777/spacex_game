using System;
using System.Collections;
using System.Collections.Generic;
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
    private Alien _alien;


    // Start is called before the first frame update
    private void Start()
    {
        // set current Alien as the one that was instantiated
        currentAlien = GetComponent<Alien>();
        StartMovingAlien();
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

    private void StartMovingAlien()
    {
        _stopMoving = false;
        _cameToShop = false;
        _movingCoroutine = StartCoroutine(MoveOverSeconds(gameObject, new Vector3(endPoint.position.x, transform.position.y, 0),
            walkingTime));
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        var startingPos = objectToMove.transform.position;

        while (elapsedTime < seconds)
        {
            if (objectToMove)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            else
            {
                StopCoroutine(_movingCoroutine);
            }
        }

        objectToMove.transform.position = end;
        _cameToShop = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            _stopMoving = true;
        }
    }
}