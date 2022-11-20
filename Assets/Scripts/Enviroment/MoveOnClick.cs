using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.EventSystems;

public class MoveOnClick : MonoBehaviour
{
    Vector3 _mousePosition;
    public float _moveSpeed = 0.1f;
    Rigidbody2D _rb;
    Vector2 _position = new Vector2(0f, 0f);

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        

    }

    private void FixedUpdate()
    {
        
    }

    private void OnMouseDrag()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        _position = Vector2.Lerp(transform.position, _mousePosition, _moveSpeed);
        transform.position = _position;
    }
}