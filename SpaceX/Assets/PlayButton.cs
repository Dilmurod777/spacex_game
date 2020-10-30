using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private Transform _player;
    private Animator _animator;
    private bool _isAppeared;
    private static readonly int Appear = Animator.StringToHash("appear");
    private static readonly int Disappear = Animator.StringToHash("disappear");

    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject.transform;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (MoveByTouch.enableMoving)
        {
            var distance = (_player.transform.position - transform.position).magnitude;
            
            if (distance < 5)
            {
                if (!_isAppeared)
                {
                    _animator.SetTrigger(Appear);
                    _isAppeared = true;
                }
            }
            else
            {
                if (_isAppeared)
                {
                    _animator.SetTrigger(Disappear);
                    _isAppeared = false;
                }
            }
        }
    }

    public void ResetTriggers()
    {
        _animator.ResetTrigger(Appear);
        _animator.ResetTrigger(Disappear);
    }
}