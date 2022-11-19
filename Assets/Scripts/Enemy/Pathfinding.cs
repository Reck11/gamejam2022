using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour {

    #region Editor-exposed
    
    public Vector2 target {
        get {
            return _target;
        }
        set {
            if (value != null) {
                hasTarget = true;
                _target = value;
            }
        }
    }
    public bool hasTarget { get; private set; }
    [SerializeField]
    private float toleranceDistance;
    [SerializeField]
    private float pathfindingUpdateDistance = 0.5f;
    #endregion
    private NavMeshAgent _agent;
    private float _timer;
    private Vector2 _target;
    void Start() {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _timer = 0;
        _target = transform.position;
    }

    private void CalculatePath() {
        if (_target == null || !hasTarget)
            return;
        _timer = 0; 
        _agent.SetDestination(_target);
    }

    void FixedUpdate() {
        CheckTolerance();
        if (_timer > pathfindingUpdateDistance) {
            CalculatePath();
        }
        _timer += Time.deltaTime;
    }

    //checks if object is within tolerance range to endpoint to stop it, or put it in motion if it is not
    private void CheckTolerance() {
        if (Vector2.Distance(transform.position, _target) < toleranceDistance) {
            _agent.isStopped = true;
            hasTarget = false;
        }
        else {
            _agent.isStopped = false;
            hasTarget = true;
        }
    }

    public float GetDistance() {
        return Vector2.Distance(_target, transform.position);
    }

    #region getters/setters

    public float GetSpeed() {
        return _agent.speed;
    }

    public void SetSpeed(float speed) { 
    _agent.speed = speed;
    }
    #endregion
}
