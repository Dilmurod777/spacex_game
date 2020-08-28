using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Alien : MonoBehaviour
{
    public List<GameObject> iceCreams;
    private GameObject _selectedIceCream;
    public int selectedIceCreamIndex = -1;
    public static Alien currentAlien;

    private Animator _animator;
    private BoxCollider2D _collider;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    public void SelectIceCream()
    {
        selectedIceCreamIndex = new Random().Next(0, iceCreams.Count);
        _selectedIceCream = Instantiate(iceCreams[selectedIceCreamIndex], transform.position,
            Quaternion.identity);
        _selectedIceCream.transform.SetParent(transform);

        Debug.Log(_animator.name);
        if (_animator.name.StartsWith("Alien (4)"))
        {
            _selectedIceCream.transform.localPosition = transform.GetChild(0).transform.localPosition + new Vector3(0, _collider.size.y / 2 + 2f, 0);
        }
        else
        {
            _selectedIceCream.transform.localPosition = transform.GetChild(0).transform.localPosition + new Vector3(0, _collider.size.y + 2f, 0);
        }
    }
}