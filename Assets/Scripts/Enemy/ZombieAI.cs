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
    protected float _attackRange;
    [SerializeField]
    protected float _detectionRange;
    [SerializeField]
    protected float _maxHealthPoints;
    #endregion
    #region Fields
    protected float _health;
    protected GameObject _player;
    protected Pathfinding _pathfinding;
    protected State _state;
    protected float _distanceToPlayer;

    #endregion

    void Awake() {
        _state = State.Idle;
        _health = _maxHealthPoints;
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _pathfinding = GetComponent<Pathfinding>();
    }

    // update state to determine what to do
    protected void UpdateState() {
        if (_player == null)
            return;

        _distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        if (_distanceToPlayer <= _detectionRange) {
            _state = State.Attack;
        }
        else _state = State.Idle;
    }

    // move by changing pathfinding script's target
    protected void Move(Vector2 target) {
        _pathfinding.target = target;
    }

    protected void Attack() {
        _pathfinding.SetSpeed(Speed);
        _pathfinding.target = _player.transform.position;
    }
    // hit player
    protected void Hit() {

    }
    public void ReceiveDamage(float damage) {
        _health -= damage;
        if (_health <= 0)
            Die();
    }
    protected void Die() {

    }
}
