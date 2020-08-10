using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometFalling : MonoBehaviour
{
    private Player _player;
    private float _distance;
    private Animator _animator;
    private float _x;
    private float _y;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _x = _player.transform.position.x - transform.position.x;
        _y = _player.transform.position.y - transform.position.y;
        _distance = new Vector2(_x, _y).magnitude;
        if(_distance < 30)
        {
            _animator.SetBool("startFalling", true);
        }
    }

    public void resetFalling()
    {
        transform.GetChild(0).transform.position = new Vector3(0, 0, 0);
        transform.GetChild(0).transform.localScale = new Vector3(0, 0, 1);
        _animator.SetBool("startFalling", false);
    }
}
