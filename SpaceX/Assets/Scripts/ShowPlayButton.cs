using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayButton : MonoBehaviour
{
    public GameObject playBtn;    
    private Player _player;

    // Start is called before the first frame update
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        playBtn.SetActive(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (MoveByTouch.enableMoving)
        {
            var distance = (_player.transform.position - transform.position).magnitude;
            
            playBtn.SetActive(distance < 5);
        }
    }
}