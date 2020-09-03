using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

enum TouchState
{
    Holding,
    Scrolling,
    Dragging,
    Released
}

public class IceCream : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public Canvas canvas;
    public ScrollRect scrollRect;
    public GameObject draggable;
    public Sprite sprite;
    public int index;

    private AlienSpawner _alienSpawner;
    private TouchState _touchState = TouchState.Released;
    private float _holdingTime = 0.75f;
    private const int NumberOfFails = 2;
    private static int _wrongChoiceCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _alienSpawner = FindObjectOfType<AlienSpawner>();
    }

    void FixedUpdate()
    {
        // Drag & Drop functionality
        // if (Input.touchCount > 0)
        // {
        //     if (_touchState == TouchState.Holding)
        //     {
        //         var angle = Vector2.Angle(Vector2.up,
        //             (Input.touches[0].position - new Vector2(transform.position.x, transform.position.y)).normalized);
        //         if (angle > 75 && angle < 105)
        //         {
        //             _touchState = TouchState.Dragging;
        //             scrollRect.vertical = false;
        //             StartDragging();
        //         }
        //         else
        //         {
        //             scrollRect.vertical = true;
        //         }
        //     }
        //
        //     // if (_touchState == TouchState.Holding)
        //     // {
        //     //     IceCreamClicked();
        //     // }
        //     // _touchState = TouchState.Released;
        // }
        // else
        // {
        //     scrollRect.vertical = true;
        //     _touchState = TouchState.Released;
        //     // if (scrollRect.velocity.y < -0.08f || scrollRect.velocity.y > 0.08f)
        //     // {
        //     //     StopAllCoroutines();
        //     //     StartCoroutine(CheckHoldingPeriod());
        //     // }
        // }

        // DebugLogTouchState();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IceCreamClicked();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _touchState = TouchState.Holding;
        // StartCoroutine(CheckHoldingPeriod());
    }

    IEnumerator CheckHoldingPeriod()
    {
        var elapsed = 0.0f;
        while (elapsed < _holdingTime)
        {
            if (_touchState == TouchState.Holding)
            {
                elapsed += Time.fixedDeltaTime;
                yield return new WaitForEndOfFrame();
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    _touchState = TouchState.Scrolling;
                }
                else
                {
                    _touchState = TouchState.Released;
                }

                yield return null;
            }
        }

        _touchState = TouchState.Dragging;
        StartDragging();
    }

    void StartDragging()
    {
        scrollRect.vertical = false;
        GameObject createdDraggable = Instantiate(draggable, transform.position, quaternion.identity);
        createdDraggable.GetComponent<Image>().sprite = sprite;
        createdDraggable.transform.SetParent(canvas.transform);
        // draggable.transform.position = Input.touches[0].position;
        // draggable.GetComponent<Image>().sprite = sprite;
        // draggable.GetComponent<Image>().enabled = true;
        // gameObject.SetActive(false);
    }

    void IceCreamClicked()
    {
        Debug.Log(_touchState + " | CLICKED");
        if (!Alien.currentAlien || Alien.currentAlien.selectedIceCreamIndex == -1)
        {
            return;
        }

        if (Alien.currentAlien.selectedIceCreamIndex == index)
        {
            Alien.currentAlien.GetComponent<Animator>().SetTrigger("gotIceCream");
            MoveAlienDestroyIceCream();
        }
        else
        {
            _wrongChoiceCount += 1;

            if (_wrongChoiceCount == NumberOfFails)
            {
                Alien.currentAlien.GetComponent<Animator>().SetTrigger("failedIceCream");
                MoveAlienDestroyIceCream();
                _wrongChoiceCount = 0;
            }
        }
    }

    private void MoveAlienDestroyIceCream()
    {
        // remove IceCream
        Destroy(Alien.currentAlien.transform.GetChild(1).gameObject);

        // Instantiate next alien
        if (AlienSpawner.notSpawnedAliens.Count > 0)
        {
            StartCoroutine(_alienSpawner.SpawnAlien(0f));
        }
    }

    void DebugLogTouchState()
    {
        switch (_touchState)
        {
            case TouchState.Holding:
                Debug.Log("HOLDING");
                break;
            case TouchState.Dragging:
                Debug.Log("DRAGGING");
                break;
            // case TouchState.Released:
            //     Debug.Log("RELEASED");
            //     break;
            case TouchState.Scrolling:
                Debug.Log("SCROLLING");
                break;
            default:
                break;
        }
    }
}