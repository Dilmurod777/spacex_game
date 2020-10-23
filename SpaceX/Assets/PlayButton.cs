using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private Transform _player;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject.transform;
    }

    private void Update()
    {
        if (MoveByTouch.enableMoving)
        {
            var distance = (_player.transform.position - transform.position).magnitude;
            
            gameObject.SetActive(distance < 5);
        }
    }
}
