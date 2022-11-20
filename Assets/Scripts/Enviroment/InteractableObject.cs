using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour {

    public KeyCode key;
    public UnityEvent interactAction;

    void Start() {
        key = KeyCode.E;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(key)) {
            interactAction.Invoke();
        }
    }
}