using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeele : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _attackRange = 0.5f;
    [SerializeField] LayerMask _enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("Enemy Hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
