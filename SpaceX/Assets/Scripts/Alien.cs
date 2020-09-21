using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Alien : MonoBehaviour
{
    public List<Sprite> iceCreams;
    public GameObject selectedIceCreamShower;
    public GameObject iceCreamHolder;
    public int selectedIceCreamIndex = -1;
    public static Alien currentAlien;
    public static bool isAnimating = true;
    
    
    private GameObject _selectedIceCream;
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
        if (selectedIceCreamShower != null)
        {
            selectedIceCreamShower.GetComponent<SpriteRenderer>().sprite = iceCreams[selectedIceCreamIndex];
        }
        if (iceCreamHolder != null)
        {
            iceCreamHolder.SetActive(true);
            iceCreamHolder.GetComponent<SpriteRenderer>().sprite = iceCreams[selectedIceCreamIndex];
        }
    }

    
    
    public void DestroyIceCream()
    {
        selectedIceCreamShower.SetActive(false);
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