using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    private GameObject player;
    private PolygonCollider2D polygonCollider2D;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        //setVisibility(false);
        player = FindObjectOfType<Player>().gameObject;
    }

    private void FixedUpdate()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if (distance < 30)
        {
            setVisibility(true);
        }
        else
        {
            setVisibility(false);
        }
    }

    public void setVisibility(bool state)
    {
        if(transform.childCount > 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
        else
        {
            spriteRenderer.enabled = state;
            polygonCollider2D.enabled = state;
        }
    }

}
