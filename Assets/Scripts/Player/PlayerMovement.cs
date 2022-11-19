using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    [SerializeField] public Rigidbody2D _rb;
    Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw(Axis.HORIZONTAL);
        _movement.y = Input.GetAxisRaw(Axis.VERTICAL);
    }

    void FixedUpdate()
    {
       _rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);
    }
}
