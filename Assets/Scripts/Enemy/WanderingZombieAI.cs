using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Enums;

public class WanderingZombieAI : ZombieAI {
    #region Editor-exposed
    [SerializeField]
    private float _wanderRange;
    [SerializeField]
    private float _minWaitTime;
    [SerializeField]
    private float _maxWaitTime;
    #endregion
    #region Fields
    private bool _shouldWander;
    private Animator _animator;
    private Vector2 _nextTarget;
    private NavMeshAgent _agent;
    private float _x;
    private float _y;

    #endregion

    new void Awake() {
        base.Awake();
        _health = _maxHealthPoints;
        _shouldWander = true;
        _animator = GetComponent<Animator>();
        _agent = _pathfinding.GetComponent<NavMeshAgent>();
    }

    void Update() {
        UpdateState();
        if (_state == State.Idle)
            Wander();
        if (_state == State.Attack)
            Attack();

        GetDirection();

    }

    // slowly pace around general area, randomly picking targets
    private void Wander() {
        _pathfinding.SetSpeed(Speed / 2);
        if (!_pathfinding.hasTarget && _shouldWander) {
            Vector2 randomDirection = Random.insideUnitCircle * _wanderRange;
            randomDirection += (Vector2)transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, _wanderRange, 1);
            Vector2 finalPosition = hit.position;
            if (Vector2.Distance(finalPosition, transform.position) < 1.0f)
                return;
            Move(finalPosition);
        }
        else if (_pathfinding.hasTarget && _pathfinding.GetDistance() < 0.5f) {
            StartCoroutine(Waiter());
        }
    }


    //wait between minWaitTime and maxWaitTime before moving again
    private IEnumerator Waiter() {
        if (!_shouldWander) // if moving is already inhibited, there is no need to start the couroutine
            yield break;

        _shouldWander = false;
        yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
        _shouldWander = true;
    }

    private void GetDirection()
    {
        _nextTarget = _agent.steeringTarget;

       



        if(Mathf.Abs(transform.position.x - _nextTarget.x) > Mathf.Abs(transform.position.y - _nextTarget.y))
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
            if(transform.position.y - _nextTarget.y < 0)
            {
                _y = 1;
            } 
            else
            {
                _y = -1;
            }

        }


        _animator.SetBool("IsMoving", _pathfinding.hasTarget);
        _animator.SetFloat("x", _x);
        _animator.SetFloat("y", _y);

    }


}
