using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackController : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float rayDistance = 5f;

    [SerializeField] private bool canAttack;

    private void Awake()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        canAttack = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            canAttack = !canAttack;
        }

        if(canAttack)
        {
            AttackRay();
        }
        else
        {
            return;
        }
    }

    private void AttackRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, enemyLayer))
        {
            if (hit.collider.CompareTag("Enemy1"))
            {
                GameObject enemy1 = hit.collider.gameObject;

                objectPool.ReturnEnemy1(enemy1);
            }
            else if (hit.collider.CompareTag("Enemy2"))
            {
                GameObject enemy2 = hit.collider.gameObject;

                objectPool.ReturnEnemy2(enemy2);
            }
        }
    }
}
