using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    Rigidbody2D _rb;
    [SerializeField] Transform _shootPoint;
    [SerializeField] Transform _centre;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _centre.position = transform.position;

    }

    void Update()
    {


        if (Input.GetAxisRaw(Axis.VERTICAL) == 1)
        {
            _centre.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetAxisRaw(Axis.VERTICAL) == -1)
        {
            _centre.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (Input.GetAxisRaw(Axis.HORIZONTAL) == 1)
        {
            _centre.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetAxisRaw(Axis.HORIZONTAL) == -1)
        {
            _centre.rotation = Quaternion.Euler(0, 0, 180);

        }

        Shoot();
        
        
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bullet, _shootPoint.position, _centre.rotation);
        }
    }
}
