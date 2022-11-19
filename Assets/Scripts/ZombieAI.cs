using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {
    
    enum State { Patrol, Attack, Dead };
    State state;

    void Awake() {
        state = State.Patrol;    
    }

    void Update() {
        
    }
}
