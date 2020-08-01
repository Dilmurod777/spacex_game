using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {
        float width = 100;
        float height = 100;
        float offset = 0;

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(width + offset, height + offset);
        setVisibility(false);
    }

    public void setVisibility(bool state)
    {
        Debug.Log(state);
        gameObject.SetActive(state);
    }

}
