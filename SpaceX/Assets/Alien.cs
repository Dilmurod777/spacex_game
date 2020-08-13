using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Transform endPoint;
    public float walkingTime = 5;
    bool stopMoving = false; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveOverSeconds(gameObject, new Vector3(endPoint.position.x, transform.position.y, 0), 5));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stopMoving)
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
       
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if(collision.tag == "Alien")
        {
            stopMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION");
        if(collision.gameObject.tag == "Alien")
        {
            stopMoving = true;
        }
    }
}
