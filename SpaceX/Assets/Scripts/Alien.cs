using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Alien : MonoBehaviour
{
    public List<GameObject> iceCreams;
    private GameObject _selectedIceCream;
    public int selectedIceCreamIndex = -1;
    public static Alien currentAlien;
    public bool iaAnimating = true;

    private AlienSpawner _alienSpawner;
    private Animator _animator;
    private BoxCollider2D _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        _alienSpawner = FindObjectOfType<AlienSpawner>();
    }

    public void SelectIceCream()
    {
        iaAnimating = false;
        selectedIceCreamIndex = new Random().Next(0, iceCreams.Count);
        _selectedIceCream = Instantiate(iceCreams[selectedIceCreamIndex], transform.position,
            Quaternion.identity);
        _selectedIceCream.transform.SetParent(transform);

        if (_animator.name.StartsWith("Alien (4)"))
        {
            _selectedIceCream.transform.localPosition = transform.GetChild(0).transform.localPosition + new Vector3(0, _collider.size.y / 2 + 2f, 0);
        }
        else
        {
            _selectedIceCream.transform.localPosition = transform.GetChild(0).transform.localPosition + new Vector3(0, _collider.size.y + 2f, 0);
        }
    }

    public void DestroyIceCream()
    {
        // remove IceCream
        Destroy(transform.GetChild(1).gameObject);
    }
    
    public void SpawnNewAlien()
    {
        // Instantiate next alien
        if (AlienSpawner.notSpawnedAliens.Count > 0)
        {
            StartCoroutine(_alienSpawner.SpawnAlien(0f));
        }
    }

    public void GotIceCream()
    {
        _animator.SetTrigger("gotIceCream");
        iaAnimating = true;
    }

    public void FailedIceCream(int count)
    {
        _animator.SetInteger("failedIceCreamCount", count);
        iaAnimating = true;
    }

    public void StartHappyWalking()
    {
        _animator.SetTrigger("startHappyWalking");
        iaAnimating = true;
        SpawnNewAlien();
    }

    public void StartSadWalking()
    {
        _animator.SetTrigger("startSadWalking");
        iaAnimating = true;
        SpawnNewAlien();
    }
    
    public void ResetAnimatorParameters()
    {
        _animator.SetInteger("failedIceCreamCount", 0);
        _animator.ResetTrigger("startHappyWalking");
        _animator.ResetTrigger("startSadWalking");
        iaAnimating = false;
    }
}