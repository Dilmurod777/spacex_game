using UnityEngine;

public class FireCometFalling : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private bool _triggered = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>().gameObject;
    }

    private void FixedUpdate()
    {
        var distance = (_player.transform.position - transform.position).magnitude;
        Debug.Log(distance);
        if (distance < 100)
        {
            if (!_triggered)
            {
                _animator.SetTrigger("startFalling");
                _triggered = true;
            }
        }
        else
        {
            _triggered = false;
            _animator.SetTrigger("resetFalling");
        }
    }
}