using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float requiredHeight = 20;
        float requiredWidth = requiredHeight * Camera.main.aspect;

        float height = Camera.main.fieldOfView;

        gameObject.GetComponent<BoxCollider>().size = new Vector3(requiredWidth, requiredHeight, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
