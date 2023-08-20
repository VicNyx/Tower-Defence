using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSpawner_Test : MonoBehaviour
{
    [Header("Spawn Locations")]
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            SpawnE1();
        }

        if(Input.GetKey(KeyCode.R))
        {
            SpawnE2();
        }

        if(Input.GetKey(KeyCode.F))
        {
            SpawnE3();
        }
    }

    private void SpawnE1()
    {
        //grab instance of enemy1 from pool
        var enemy1 = EnemyObjectPool_Test.instance.GetPooledEnemy1();

        if(enemy1 != null )
        {
            //set enemy1 pos and rot
            enemy1.transform.position = spawnPoint1.transform.position;
            enemy1.transform.rotation = spawnPoint1.transform.rotation;

            //set enemy1 active
            enemy1.SetActive(true);
        }
    }

    private void SpawnE2()
    {
        //grab instance of enemy2 from pool
        var enemy2 = EnemyObjectPool_Test.instance.GetPooledEnemy2();

        if (enemy2 != null)
        {
            //set enemy2 pos and rot 
            enemy2.transform.position = spawnPoint2.transform.position;
            enemy2.transform.rotation = spawnPoint2.transform.rotation;

            //set enemy2 active
            enemy2.SetActive(true);
        }
    }

    private void SpawnE3()
    {
        //grab instance of enemy3 from pool
        var enemy3 = EnemyObjectPool_Test.instance.GetPooledEnemy3();

        if (enemy3 != null)
        {
            //set enemy3 pos and rot
            enemy3.transform.position = spawnPoint3.transform.position;
            enemy3.transform.rotation = spawnPoint3.transform.rotation;

            //set enemy3 active
            enemy3.SetActive(true);
        }
    }
}
