using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class ZombieAI : MonoBehaviour, IEnemy {

    #region Editor-exposed
    public float Damage;
    public MovementType MovementType;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _detectionRange;
    [SerializeField]
    private float _healthPoints;
    #endregion
    #region Fields
    private float _health;
    private GameObject _player;
    private Pathfinding _pathfinding;
    private State _state;
    private float _distanceToPlayer;

    #endregion

    void Awake() {
        _state = State.Idle;
        _health = _healthPoints;
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _pathfinding = GetComponent<Pathfinding>();
    }

    void Update() {
        UpdateState();
        if (_state == State.Idle)
            Idle();
        if (_state == State.Attack)
            Attack();
    }

    // update state to determine what to do
    private void UpdateState() {
        _distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (_distanceToPlayer <= _detectionRange) {
            _state = State.Attack;
        }
        else _state = State.Idle;
    }
    // different behaviours for different movement types
    private void Idle() {
        switch (MovementType) {
            case MovementType.Patrolling:
                Patrol();
                break;
            case MovementType.Wandering:
                Wander();
                break;
            default:
                Debug.LogError("Invalid enemy type for " + gameObject.name);
                break;
        }
    }

    private void Wander() {

    }

    private void Patrol() { 
        
    }
    // move by changing pathfinding script's target
    private void Move(Vector2 target) {
        _pathfinding.Target = target;
    }

    private void Attack() {
        
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
