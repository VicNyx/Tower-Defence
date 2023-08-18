using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool_Test : MonoBehaviour
{
    public static EnemyObjectPool_Test instance;

    [Header("Objects")] //set any objects that need to be pooled
    [SerializeField] private GameObject enemy1Prefab;
    [SerializeField] private GameObject enemy2Prefab;
    [SerializeField] private GameObject enemy3Prefab;

    [Header("Limits")] //set seperate limits if need be
    [SerializeField] private int enemy1Limit = 10;
    [SerializeField] private int enemy2Limit = 10;
    [SerializeField] private int enemy3Limit = 10;

    //create list of each object
    private List<GameObject> enemy1Pool = new List<GameObject>();
    private List<GameObject> enemy2Pool = new List<GameObject>();
    private List<GameObject> enemy3Pool = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        InitialzePools();
    }

    #region Pool Logic

    private void InitialzePools()
    {
        //enemy 1 pools
        for (int i = 0; i < enemy1Limit; i++)
        {
            GameObject enemy1 = Instantiate(enemy1Prefab);
            enemy1.SetActive(false);

            enemy1Pool.Add(enemy1);
        }

        //enemy 2 pools
        for (int i = 0; i < enemy2Limit; i++)
        {
            GameObject enemy2 = Instantiate(enemy2Prefab);
            enemy2.SetActive(false);

            enemy2Pool.Add(enemy2);
        }

        //enemy 3 pools
        for (int i = 0; i < enemy3Limit; i++)
        {
            GameObject enemy3 = Instantiate(enemy3Prefab);
            enemy3.SetActive(false);

            enemy3Pool.Add(enemy3);
        }
    }

    #endregion

    #region Pools


    //call these fucntions to "spawn in" the enemies
    public GameObject GetPooledEnemy1()
    {
        //get enemy 1 from pool, set return logic in death logic on enemy1
        for(int i = 0; i < enemy1Pool.Count; i++)
        {
            if (!enemy1Pool[i].activeInHierarchy)
            {
                return enemy1Pool[i];
            }
        }

        return null;
    }

    public GameObject GetPooledEnemy2()
    {
        //get enemy 2 from pool, set return logic in death logic on enemy2
        for (int i = 0; i < enemy2Pool.Count; i++)
        {
            if (!enemy2Pool[i].activeInHierarchy)
            {
                return enemy2Pool[i];
            }
        }

        return null;
    }

    public GameObject GetPooledEnemy3()
    {
        //get enemy 3 from pool, set return logic in death logic on enemy3
        for (int i = 0; i < enemy3Pool.Count; i++)
        {
            if (!enemy3Pool[i].activeInHierarchy)
            {
                return enemy3Pool[i];
            }
        }

        return null;
    }

    #endregion
}

/* @Tysonn J. Smith 2023
 * 
 * Made a simple object pool for 3 enemies, based off my objectpool script in Witch and Wizzle
 * which is using the tutorial @bendux - Introduction To Object Pooling In Unity
 * https://www.youtube.com/watch?v=YCHJwnmUGDk
 * 
 * will use this to build upon all the pools needed, such as projectiles,
 * anything that is spawned in and destroyed regularly.
 * 
 * 
 * examples on how to spawn in an object is in ObjectPoolSpawner_Test
 * 
 * TODO: build example on despawning enemies and returning them to the pool
 * set up logic for a test wave spawner, prob on a button press for testing
 * and spawning a set amount multiplied by the round number (and/ or difficulty.)
 * 
 * 
 * 
 * 
 */