using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackRangeCheck : MonoBehaviour
{
    public GameObject enemyTarget { get; set; }
    private Tower tower;

    private void Awake()
    {
        enemyTarget = GameObject.FindGameObjectWithTag("Enemy");

        tower = GetComponent<Tower>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == enemyTarget)
        {
            tower.SetAttackRangeBool(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == enemyTarget)
        {
            tower.SetAttackRangeBool(false);
        }
    }
}
