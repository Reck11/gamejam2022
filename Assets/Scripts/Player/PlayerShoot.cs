using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _centre;
    [SerializeField] private int _maxAmmo = 6;
    [SerializeField] private float _reloadTime = 1.0f;
    [SerializeField] private int _maxMagazine = 2;
    [SerializeField] private int _damage;
    private Rigidbody2D _rb;
    private int _magazineAmmount;
    private int _currentAmmo;
    private bool _isReloading;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _centre.position = transform.position;
        _currentAmmo = _maxAmmo;
        _magazineAmmount = _maxMagazine;
        GameEvents.OnAmmoPickup += AddMagazine;
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

    void AddMagazine(int magazineAmmount)
    {
        if(_magazineAmmount >= _maxMagazine)
        {
            Debug.Log("Max magazine ammount added bullets to current magazine");
            _currentAmmo = _maxAmmo;
            return;
        }

        _magazineAmmount += magazineAmmount;
        Debug.Log("Magazine picked up");
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isReloading)
            {
                return;
            }

            if (_currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }
            var shotBullet = Instantiate(_bullet, _shootPoint.position, _centre.rotation);
            shotBullet.GetComponent<Bullet>().SetDamage(_damage);
            _currentAmmo--;

        }
    }

    IEnumerator Reload()
    {
        _isReloading = true;
        while(_magazineAmmount <= 0)
        {
            Debug.Log("Out of Magazines");
            yield return null;
        }

        Debug.Log("Reload...");

        yield return new WaitForSeconds(_reloadTime);

        _currentAmmo = _maxAmmo;
        _magazineAmmount--;
        _isReloading = false;

    }
}
