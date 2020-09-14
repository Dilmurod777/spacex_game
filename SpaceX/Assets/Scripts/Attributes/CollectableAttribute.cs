using UnityEngine;

[AddComponentMenu("Playground/Attributes/Collectable")]
public class CollectableAttribute : MonoBehaviour
{
	private Animator _animator;
	private void Start()
	{
		_animator = GetComponent<Animator>();
	}
	
	// This function gets called everytime this object collides with another
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		string playerTag = otherCollider.gameObject.tag;

		if(playerTag == "Player" || playerTag == "Player2")
		{
			_animator.SetTrigger("isDead");
		}
	}

	public void destroyAfterAnimation()
	{
		_animator.SetTrigger("isDead");
		Destroy(gameObject);
	}
}
