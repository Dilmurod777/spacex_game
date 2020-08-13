using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayButton : MonoBehaviour
{
    public GameObject playBtn;
    public Canvas canvas;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        playBtn.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (_player.transform.position - transform.position).magnitude;

        if (distance < 15)
        {
            playBtn.SetActive(true);
        }
        else
        {
            playBtn.SetActive(false);
        }
    }
}
