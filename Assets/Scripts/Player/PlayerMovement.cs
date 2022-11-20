using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _speed = 250f;
    [SerializeField] public Rigidbody2D _rb;
    private Vector2 direction;

    private Animator _animator;

    private float _x, _y;

    private bool isWalking;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _x = Input.GetAxisRaw(Axis.HORIZONTAL);
        _y = Input.GetAxisRaw(Axis.VERTICAL);

        if (_x != 0 || _y != 0)
        {
            _animator.SetFloat("Horizontal", _x);
            _animator.SetFloat("Vertical", _y);
            if (!isWalking)
            {
                isWalking = true;
                _animator.SetBool("isMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                _animator.SetBool("isMoving", isWalking);
                StopMoving();
            }
        }
        direction = new Vector2(_x, _y).normalized;
    }

    void StopMoving()
    {
        _rb.velocity = Vector2.zero; 
    }

    void FixedUpdate()
    {
        _rb.velocity = direction * _speed * Time.deltaTime; 
    }




    /* Vector2 _movement;



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
     }*/
}
