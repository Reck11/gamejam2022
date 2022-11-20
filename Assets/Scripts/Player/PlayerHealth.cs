using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    private float _health;
    [SerializeField]
    private List<MonoBehaviour> _scriptsToDisable;
    [SerializeField]
    private GameObject _gameManager;

    void Start() {
        _health = maxHealth;
    }

    public void ReceiveDamage(float damage) {
        _health -= damage;
        if (_health <= 0)
            Die();
    }
    private void Die() {
        foreach (MonoBehaviour script in _scriptsToDisable) {
            script.enabled = false;
        }
    }
}
