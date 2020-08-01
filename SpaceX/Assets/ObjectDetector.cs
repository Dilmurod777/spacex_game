using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        float offset = 15f;

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(width + offset, height + offset);
    }
}
