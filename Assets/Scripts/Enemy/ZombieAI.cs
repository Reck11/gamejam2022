using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Enums;

public class ZombieAI : MonoBehaviour, IEnemy {

    #region Editor-exposed
    public float Damage;
    public float Speed;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _wanderRange;
    [SerializeField]
    private float _detectionRange;
    [SerializeField]
    private float _minWaitTime;
    [SerializeField]
    private float _maxWaitTime;
    [SerializeField]
    private float _maxHealthPoints;
    #endregion
    #region Fields
    private Vector2 _wanderPoint;
    private float _health;
    private bool _shouldWander;
    private GameObject _player;
    private Pathfinding _pathfinding;
    private State _state;
    private float _distanceToPlayer;

    #endregion

    void Awake() {
        _state = State.Idle;
        _health = _maxHealthPoints;
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _pathfinding = GetComponent<Pathfinding>();
        _shouldWander = true;
    }

    void Update() {
        UpdateState();
        if (_state == State.Idle)
            Wander();
        if (_state == State.Attack)
            Attack();
    }

    // update state to determine what to do
    private void UpdateState() {
        if (_player == null)
            return;

        _distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (_distanceToPlayer <= _detectionRange) {
            _state = State.Attack;
        }
        else _state = State.Idle;
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

    // move by changing pathfinding script's target
    private void Move(Vector2 target) {
        _pathfinding.target = target;
    }

    private void Attack() {
        _pathfinding.SetSpeed(Speed);
        _pathfinding.target = _player.transform.position;
    }
    // hit player
    private void Hit() {

    }
    public void ReceiveDamage(float damage) {
        _health -= damage;
        if (_health <= 0)
            Die();
    }
    private void Die() {

    }
}
