using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    //GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        setVisibility(false);
        //player = FindObjectOfType<Player>().gameObject;
    }

    private void FixedUpdate()
    {
        //Debug.Log((player.transform.position - transform.position).magnitude);
        //if ((player.transform.position - transform.position).magnitude > 10)
        //{
        //    setVisibility(false);
        //}
        //else
        //{
        //    setVisibility(true);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "PlayerObjectDetector")
        //{
        //    setVisibility(true);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.tag == "PlayerObjectDetector")
        //{
        //    setVisibility(false);
        //}
    }

    public void setVisibility(bool state)
    {
        //for(int i=0; i < gameObject.transform.childCount; i++)
        //{
        //    transform.GetChild(i).gameObject.SetActive(state);
        //}
    }

}
