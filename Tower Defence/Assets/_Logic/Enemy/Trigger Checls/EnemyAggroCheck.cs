using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{
    public GameObject playerTarget { get; set; }
    private Enemy enemy;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");

        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == playerTarget)
        {
            enemy.SetAggroStatus(true);
        }
    }    
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == playerTarget)
        {
            enemy.SetAggroStatus(false);
        }
    }
}
