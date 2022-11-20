using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {

    [SerializeField] private float _coolDown = 1.0f;
    private bool _playerIsInLocker = false;
    private bool _canInteract = true;
    private GameObject _player;
    private List<MonoBehaviour> _components = new List<MonoBehaviour>();
    private BoxCollider2D _boxCollider;

    void Start() {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _components.Add(_player.GetComponent<PlayerMovement>());
        _components.Add(_player.GetComponent<PlayerShoot>());
        _components.Add(_player.GetComponent<PlayerMeele>());
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void EnterLocker() {
        if (_playerIsInLocker || !_canInteract)
            return;
        StartCoroutine(LockerWaiter());
        _playerIsInLocker = true;
        foreach (MonoBehaviour comp in _components) {
            comp.enabled = false;
        }
        _player.transform.position = transform.position;
        _player.GetComponent<SpriteRenderer>().enabled = false;
        _boxCollider.enabled = false;
    }
    public void ExitLocker() {
        if (!_playerIsInLocker || !_canInteract)
            return;
        StartCoroutine(LockerWaiter());
        _playerIsInLocker = false;
        foreach (MonoBehaviour comp in _components) {
            comp.enabled = true;
        }
        _player.transform.position = new Vector2(transform.position.x, transform.position.y - 1.5f);
        _player.GetComponent<SpriteRenderer>().enabled = true;
        _boxCollider.enabled = true;
    }
    private IEnumerator LockerWaiter() {
        if (!_canInteract)
            yield break;
    
        _canInteract = false;
        yield return new WaitForSeconds(_coolDown);
        _canInteract = true;
    }
}
