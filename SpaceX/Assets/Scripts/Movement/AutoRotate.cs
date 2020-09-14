using UnityEngine;

public class AutoRotate : MonoBehaviour
{
	public float angle = 5;
	
	void FixedUpdate ()
	{
		transform.Rotate(0, 0, angle);
	}
}
