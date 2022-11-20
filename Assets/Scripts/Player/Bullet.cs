using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    private GameObject _player;
    private int _damage = 0;
    Vector2 _direction;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 cannonballVector = transform.right * _bulletSpeed;
        rb.velocity = cannonballVector;
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
    }

    public void SetDamage(int damage) {
        _damage = damage;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY))
        {
            var IEnemy = collision.gameObject.GetComponent<IEnemy>();
            IEnemy.ReceiveDamage(_damage);
        }
        Destroy(gameObject);
    }

}
