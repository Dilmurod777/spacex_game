using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float angle = 5;
    
    void FixedUpdate()
    {
        transform.Rotate(0, 0, angle);
    }

    // This function gets called everytime this object collides with another
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        string playerTag = otherCollider.gameObject.tag;

        if (playerTag == "Player" || playerTag == "Player2")
        {
            GetComponent<Animator>().SetTrigger("isDead");
        }
    }

    public void destroyAfterAnimation()
    {
        GetComponent<Animator>().SetTrigger("isDead");
        Destroy(gameObject);
    }
}