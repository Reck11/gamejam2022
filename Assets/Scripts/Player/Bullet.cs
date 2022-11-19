using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;

    [SerializeField] GameObject _player;
    Vector2 _direction;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 cannonballVector = transform.right * _bulletSpeed;
        rb.velocity = cannonballVector;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
