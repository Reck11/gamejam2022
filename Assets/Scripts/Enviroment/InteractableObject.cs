using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour {

    public KeyCode key;
    public UnityEvent interactAction;
    private bool _inTrigger;

    void Start() {
        key = KeyCode.E;
    }

    void Update() {
        if (_inTrigger && Input.GetKeyDown(key))
            interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _inTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _inTrigger = false;
        }
    }
}