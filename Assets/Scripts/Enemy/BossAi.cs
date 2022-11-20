using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Enums;

public class BossAi : ZombieAI
{
    #region Editor-exposed
    [SerializeField]
    private float _wanderRange;
    [SerializeField]
    private float _waitTime;
    #endregion
    #region Fields
    private Animator _animator;
    private Vector2 _nextTarget;
    private float _x;
    private float _y;
    private bool _isMoving;
    #endregion

    new void Awake()
    {
        base.Awake();

        _animator = GetComponent<Animator>();
        _isMoving = true;
    }

    void Update()
    {
        UpdateState();
        if (_state == State.Idle)
            Chase();
        if (_state == State.Attack)
            Attack();
        GetDirection();
    }


    private void Chase()
    {
        _pathfinding.target = _player.transform.position;
    }

    //wait between minWaitTime and maxWaitTime before moving again
    private IEnumerator Waiter()
    {
        _isMoving = false;
        yield return new WaitForSeconds(_waitTime);
        _isMoving = true;
        Chase();
    }

    private void GetDirection()
    {
        _nextTarget = _player.transform.position;



        if (Mathf.Abs(transform.position.x - _nextTarget.x) > Mathf.Abs(transform.position.y - _nextTarget.y))
        {
            _y = 0;
            if (transform.position.x - _nextTarget.x < 0)
            {
                _x = 1;
            }
            else
            {
                _x = -1;
            }

        }
        else
        {
            _x = 0;
            if (transform.position.y - _nextTarget.y < 0)
            {
                _y = 1;
            }
            else
            {
                _y = -1;
            }

        }


        _animator.SetBool("IsMoving", _isMoving);
        _animator.SetFloat("x", _x);
        _animator.SetFloat("y", _y);

    }

    public override void ReceiveDamage(float damage)
    {
        Debug.Log("Damage");
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Waiter());
        }

    }
}
