using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Alien"))
        {
            other.GetComponent<Alien>().StopMovingCoroutine();
            Destroy(other.gameObject);
        }
    }
}
