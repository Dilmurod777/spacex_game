using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Alien : MonoBehaviour
{
    public List<GameObject> iceCreams;
    private GameObject _selectedIceCream;
    public int selectedIceCreamIndex = -1;
    public static Alien currentAlien;
    public static bool isAnimating = true;

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
        isAnimating = false;
        selectedIceCreamIndex = new Random().Next(0, iceCreams.Count);
        _selectedIceCream = Instantiate(iceCreams[selectedIceCreamIndex], transform.position,
            Quaternion.identity);
        _selectedIceCream.transform.SetParent(transform);
        _selectedIceCream.transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);

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
        transform.GetChild(1).gameObject.SetActive(false);
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
        isAnimating = true;
        _animator.SetTrigger("gotIceCream");
    }

    public void FailedIceCream(int count)
    {
        isAnimating = true;
        _animator.SetInteger("failedIceCreamCount", count);
    }

    public void StartHappyWalking()
    {
        isAnimating = true;
        _animator.SetTrigger("startHappyWalking");
        SpawnNewAlien();
    }

    public void StartSadWalking()
    {
        isAnimating = true;
        _animator.SetTrigger("startSadWalking");
        SpawnNewAlien();
    }
    
    public void ResetAnimatorParameters()
    {
        _animator.SetInteger("failedIceCreamCount", 0);
        _animator.ResetTrigger("startHappyWalking");
        _animator.ResetTrigger("startSadWalking");
        isAnimating = false;
    }
}