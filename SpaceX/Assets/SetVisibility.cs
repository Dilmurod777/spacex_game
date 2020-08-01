using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    private List<Vector2> points;
    
    // Start is called before the first frame update
    private void Start()
    {
        setVisibility(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerObjectDetector")
        {
            setVisibility(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        //{
        //    setVisibility(true);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerObjectDetector")
        {
            setVisibility(false);
        }
    }

    public void setVisibility(bool state)
    {
        for(int i=0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }

}
