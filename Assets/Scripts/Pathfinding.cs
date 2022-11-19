using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour {

    public Transform target;
    private NavMeshAgent _agent;
    void Start() {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void CalculatePath() {
        _agent.SetDestination(target.position);
    }

    void Update() {
        CalculatePath();
    }
}
