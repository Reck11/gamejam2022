using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _speed = 250f;
    [SerializeField] public Rigidbody2D _rb;
    private Vector2 direction;

   public Animator animator;

    public float x, y;

    private bool isWalking;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw(Axis.HORIZONTAL);
        y = Input.GetAxisRaw(Axis.VERTICAL);

        if (x != 0 || y != 0)
        {
            animator.SetFloat("Horizontal", x);
            animator.SetFloat("Vertical", y);
            if (!isWalking)
            {
                isWalking = true;
                animator.SetBool("isMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                animator.SetBool("isMoving", isWalking);
                StopMoving();
            }
        }
        direction = new Vector2(x, y).normalized;
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
