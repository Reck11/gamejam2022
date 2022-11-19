using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour {

    #region Editor-exposed
    public float Speed {
        get {
            return _agent.speed;
        }
        set { 
            _agent.speed = value;
        }
    }
    public Vector2 Target { get; set; }
    #endregion
    private NavMeshAgent _agent;
    void Start() {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void CalculatePath() {
        _agent.SetDestination(Target);
    }

    void Update() {
        CalculatePath();
    }
}
