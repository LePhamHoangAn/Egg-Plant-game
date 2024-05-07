using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropGO : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject hand;


    [SerializeField] private float _speed = 10;
   
    void Awake()
    {
        _cam = Camera.main;
    }

    void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Background1")
        {
            background1.SetActive(false);
            background2.SetActive(true);
            background3.SetActive(false);
            hand.SetActive(false);
        }

    }
}
