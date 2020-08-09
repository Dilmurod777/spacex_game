using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if(distance < 30)
        {
            setVisibility(true);
        }
        else
        {
            setVisibility(false);
        }
    }

    private void setVisibility(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }
}
