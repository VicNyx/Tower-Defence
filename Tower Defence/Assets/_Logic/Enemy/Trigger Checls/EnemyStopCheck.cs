using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopCheck : MonoBehaviour
{
    public GameObject playerTarget { get; set; }
    public GameObject objectiveTransform { get; set; }
    private Enemy enemy;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        objectiveTransform = GameObject.FindGameObjectWithTag("Objective");

        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == playerTarget || collision.gameObject == objectiveTransform)
        {
            enemy.SetStopStatus(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == playerTarget || collision.gameObject == objectiveTransform)
        {
            enemy.SetStopStatus(false);
        }
    }
}
